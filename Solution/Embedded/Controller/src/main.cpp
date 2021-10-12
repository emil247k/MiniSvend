#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESPAsyncTCP.h>
#include <ESPAsyncWebServer.h>

AsyncWebServer server(80);

char* ssid = "";
char* password = "YOUR_PASSWORD";

char webpage[] PROGMEM = R"=====(
<html>
<head>
  <script> </script>
</head>
<body>
  <div>
    <textarea id="rxConsole"></textarea>
  </div> 
</body>
</html>
)=====";

void setup()
{
  WiFi.begin(ssid,password);
  Serial.begin(115200);
  while(WiFi.status()!=WL_CONNECTED)
  {
    Serial.print(".");
    delay(500);
  }
  Serial.println("");
  Serial.print("IP Address: ");
  Serial.println(WiFi.localIP());


  server.on("/", HTTP_GET, [](AsyncWebServerRequest *request){
    request->send_P(200, "text/plain", webpage);
  });

  server.on("/unlock", HTTP_GET,[](AsyncWebServerRequest *request){
    request->send_P(200,"text/html", "unlocked");
  });
  server.begin();
  
}

void loop()
{
}
