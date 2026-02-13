# SmoothStrike - Användarmanual

## Innehållsförteckning
1. [Översikt](#översikt)
2. [Installation och Konfiguration](#installation-och-konfiguration)
3. [URL-struktur och Endpoints](#url-struktur-och-endpoints)
4. [Overlay-länk (OVR)](#overlay-länk-ovr)
5. [Streaming Push API](#streaming-push-api)
6. [SignalR Hub](#signalr-hub)
7. [Exempel](#exempel)

---

## Översikt

SmoothStrike är ett system för att hantera och visa taekwondo-matcher i realtid. Systemet består av:
- En ASP.NET Core backend-server
- En overlay för livestreaming (OBS/Streamlabs)
- Ett real-time kommunikationssystem med SignalR
- TCP och UDP servrar för att ta emot matchdata

---

## Installation och Konfiguration

### Systemkrav
- .NET 6.0 eller senare
- SQL Server (LocalDB eller full installation)
- Webbläsare med stöd för SignalR (Chrome, Firefox, Edge)

### Serverporten
Applikationen körs som standard på:
- **HTTP**: `http://localhost:5042`
- **HTTPS**: `https://localhost:7138`
- **TCP Server**: `127.0.0.1:8080` (för push-meddelanden)

### Starta servern
```bash
cd MyApi
dotnet run
```

---

## URL-struktur och Endpoints

### Base URL
```
http://localhost:5042
```

### API Endpoints

#### 1. Status och Hälsokontroll
```
GET /status
Response: "Hell yeah, it's working!"
```

#### 2. Ping för specifik mattbit
```
GET /tks/{matchCode}/events-listener/ping
Response: "Hell yeah, it's working!"
```

#### 3. Hämta matchinformation
```
GET /tks/{matchCode}/events-listener/match/{matchNumber}
Response: JSON med matchdata
```

**Exempel:**
```
GET /tks/mat-1/events-listener/match/5
```

#### 4. Ny match konfigurerad
```
POST /tks/{matchCode}/events-listener/new-match-configured
Content-Type: application/json

Body:
{
  "matchNumber": 5,
  "mat": "mat-1",
  "blueAthlete": {
    "scoreboardName": "Blå Utövare"
  },
  "redAthlete": {
    "scoreboardName": "Röd Utövare"
  },
  "category": {
    "name": "HERR",
    "subCategory": "NYBÖRJARE",
    "weightClass": "-55 KG"
  },
  "phase": "FINAL"
}
```

#### 5. Ny matchhändelse
```
POST /tks/{matchCode}/events-listener/new-match-event
Content-Type: application/json

Body:
{
  "matchNumber": 5,
  "eventType": "BLUE_BODY_POINT"
}
```

**Tillgängliga händelsetyper:**
- `START_MATCH` - Match startar
- `END_ROUND` - Rond avslutas
- `BLUE_PUNCH_POINT` - Blå poäng (slag)
- `BLUE_BODY_POINT` - Blå poäng (kropp)
- `BLUE_BODY_TECH_POINT` - Blå teknisk poäng (kropp)
- `BLUE_HEAD_POINT` - Blå poäng (huvud)
- `BLUE_HEAD_TECH_POINT` - Blå teknisk poäng (huvud)
- `BLUE_ADD_GAME_JEON` - Blå varning
- `BLUE_VIDEO_REQUEST` - Blå video begäran
- `BLUE_VIDEO_QUOTA_ACCEPTED` - Blå video accepterad
- `RED_PUNCH_POINT` - Röd poäng (slag)
- `RED_BODY_POINT` - Röd poäng (kropp)
- `RED_BODY_TECH_POINT` - Röd teknisk poäng (kropp)
- `RED_HEAD_POINT` - Röd poäng (huvud)
- `RED_HEAD_TECH_POINT` - Röd teknisk poäng (huvud)
- `RED_ADD_GAME_JEON` - Röd varning
- `RED_VIDEO_REQUEST` - Röd video begäran
- `RED_VIDEO_QUOTA_ACCEPTED` - Röd video accepterad

#### 6. Matchresultat
```
POST /tks/{matchCode}/events-listener/match-result
Content-Type: application/json

Body:
{
  "matchNumber": 5,
  "winner": "BLUE"
}
```

---

## Overlay-länk (OVR)

### URL för Overlay
```
http://localhost:5042/tks/overlay?mat={MAT_CODE}
```

### Query String-parametrar

#### Obligatorisk parameter:
- **`mat`** - Mattans identifierare (t.ex. "1", "2", "3")

#### Valfri parameter:
- **`debug`** - Aktiverar debug-läge med bakgrundsbild

### Exempel på Overlay-länkar

**För matta 1:**
```
http://localhost:5042/tks/overlay?mat=1
```

**För matta 2:**
```
http://localhost:5042/tks/overlay?mat=2
```

**För matta 3 med debug-läge:**
```
http://localhost:5042/tks/overlay?mat=3&debug=true
```

### Hur man använder Overlay i OBS/Streamlabs

1. Öppna OBS/Streamlabs
2. Lägg till en ny källa (Browser Source)
3. Kopiera overlay-länken med rätt mattidentifierare
4. Ange bredd: 1920 och höjd: 1080 (eller anpassa efter behov)
5. Markera "Shutdown source when not visible" (valfritt)
6. Klicka på OK

Overlay:et visar:
- Matchnummer och kategori
- Utövarnas namn (blå och röd)
- Poäng och rundvinster
- Varningar
- Realtidshändelser under matchen

---

## Streaming Push API

### TCP Push Server

Servern lyssnar på:
```
IP: 127.0.0.1
Port: 8080
```

### Meddelandeformat

Meddelanden skickas som TCP-strömmar i följande format:
```
XXXXXX{Command}:{Data}
```

Där:
- `XXXXXX` = 6 tecken för meddelandelängd
- `Command` = Kommandonamn
- `Data` = Kommaavgränsade data

### Tillgängliga kommandon

#### NewMatch
```
005601NewMatch:1-3,Blå,,Röd,,MALE,NYBÖRJARE / HERR / -55 KG
```

#### MatchStart
```
000012MatchStart:
```

#### RoundStart
```
000011RoundStart:
```

#### Score
```
000020Score:BLUE,2,HEAD
```

#### Timeout
```
000008Timeout:
```

#### Resume
```
000007Resume:
```

#### RoundEnd
```
000009RoundEnd:
```

#### MatchEnd
```
000009MatchEnd:
```

### Exempel på C# TCP-klient

```csharp
using System.Net.Sockets;
using System.Text;

var client = new TcpClient("127.0.0.1", 8080);
var stream = client.GetStream();

string message = "000012MatchStart:";
byte[] data = Encoding.UTF8.GetBytes(message);
await stream.WriteAsync(data, 0, data.Length);

client.Close();
```

---

## SignalR Hub

### Hub URL
```
http://localhost:5042/hub
```

### Anslutning till Hub

**JavaScript-exempel:**
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

await connection.start();
console.log("Connected to SignalR Hub");
```

### Gå med i en mattgrupp

Varje matta har en egen SignalR-grupp:
```javascript
const matCode = "1";
const matGroup = "mat-" + matCode;
await connection.invoke("JoinGroup", matGroup);
```

### Lyssna på händelser

#### new-match-configured
```javascript
connection.on("new-match-configured", (user, message) => {
    console.log("Ny match konfigurerad:", message);
    // message innehåller matchdata
});
```

#### new-match-event
```javascript
connection.on("new-match-event", (user, message) => {
    console.log("Ny matchhändelse:", message.eventType);
    // message innehåller händelsedata
});
```

#### match-result
```javascript
connection.on("match-result", (user, message) => {
    console.log("Matchresultat:", message);
    // message innehåller resultatdata
});
```

---

## Exempel

### Komplett exempel: Starta en match med overlay

#### Steg 1: Starta servern
```bash
cd MyApi
dotnet run
```

#### Steg 2: Öppna overlay i webbläsare eller OBS
```
http://localhost:5042/tks/overlay?mat=1
```

#### Steg 3: Konfigurera en ny match (med curl eller Postman)
```bash
curl -X POST http://localhost:5042/tks/mat-1/events-listener/new-match-configured \
  -H "Content-Type: application/json" \
  -d '{
    "matchNumber": 1,
    "mat": "mat-1",
    "blueAthlete": {
      "scoreboardName": "Johan Andersson"
    },
    "redAthlete": {
      "scoreboardName": "Maria Svensson"
    },
    "category": {
      "name": "HERR",
      "subCategory": "SENIOR",
      "weightClass": "-68 KG"
    },
    "phase": "SEMIFINAL"
  }'
```

#### Steg 4: Skicka matchhändelser
```bash
# Starta matchen
curl -X POST http://localhost:5042/tks/mat-1/events-listener/new-match-event \
  -H "Content-Type: application/json" \
  -d '{
    "matchNumber": 1,
    "eventType": "START_MATCH"
  }'

# Blå får poäng
curl -X POST http://localhost:5042/tks/mat-1/events-listener/new-match-event \
  -H "Content-Type: application/json" \
  -d '{
    "matchNumber": 1,
    "eventType": "BLUE_BODY_POINT"
  }'

# Röd får poäng
curl -X POST http://localhost:5042/tks/mat-1/events-listener/new-match-event \
  -H "Content-Type: application/json" \
  -d '{
    "matchNumber": 1,
    "eventType": "RED_HEAD_TECH_POINT"
  }'
```

#### Steg 5: Avsluta matchen
```bash
curl -X POST http://localhost:5042/tks/mat-1/events-listener/match-result \
  -H "Content-Type: application/json" \
  -d '{
    "matchNumber": 1,
    "winner": "BLUE"
  }'
```

---

## Felsökning

### Overlay visar ingen data
- Kontrollera att `mat` query-parametern är korrekt
- Öppna webbläsarens konsol (F12) för att se eventuella felmeddelanden
- Verifiera att servern körs på rätt port

### SignalR-anslutning misslyckas
- Kontrollera att servern är startad
- Verifiera att `/hub`-endpoint är tillgänglig
- Kolla brandväggar och nätverksinställningar

### TCP-servern tar inte emot meddelanden
- Verifiera att servern lyssnar på `127.0.0.1:8080`
- Kontrollera att meddelandeformatet är korrekt
- Se serverloggar för eventuella fel

---

## Teknisk support

För frågor eller problem, kontakta utvecklingsteamet eller skapa en issue i projektets repository.
