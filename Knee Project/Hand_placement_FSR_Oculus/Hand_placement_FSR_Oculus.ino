
const int sensor1 = A0 ;
const int sensor2 = A1 ;

int valSensor1 = 0 ;
int valSensor2 = 0 ;

const int LED_sensor1 = 3 ;
const int LED_sensor2 = 4 ;

const int interval = 100   ;
unsigned long prevTime = 0 ;


void setup() {

  Serial.begin(38400);
  pinMode(LED_sensor1, OUTPUT) ;
  pinMode(LED_sensor2, OUTPUT) ;
  
}


void loop() {

  unsigned long currentTime = millis();

  valSensor1 = analogRead(sensor1) ;
  valSensor2 = analogRead(sensor2) ;

  if (currentTime - prevTime){

    Serial.print(valSensor1)   ;
    Serial.print(", ")         ;
    Serial.println(valSensor2) ;

    prevTime = currentTime   ;
    
  }

}
