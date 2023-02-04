
// EMULATING KNEE PROJECT SENSORS WITH POTENTIOMETERS AND BUTTONS TO BUILD UNITY UI //

#define LedPin 12
#define PB1CC  10
#define PB1CCW 11

int UpperPot  = 0 ;
int Lower1Pot = 1 ;
int Lower2Pot = 2 ;

int LEDbrightness ;
int Upper_value   ;
int Lower1_value  ;
int Lower2_value  ;

unsigned long prevTime = 0 ;
long interval_sample = 50  ;


void setup() {
  
  Serial.begin(38400)       ;
  pinMode(LedPin, OUTPUT)   ;
  digitalWrite(LedPin, LOW) ;
  pinMode(PB1CC, INPUT)     ;
  pinMode(PB1CCW, INPUT)    ;
  
}


void loop() {

  unsigned long currentTime = millis();

 // Task 1: Controlling Ligaments with Push-Buttons //

  Upper_value = analogRead(UpperPot)   ;
  Lower1_value = analogRead(Lower1Pot) ;
  Lower2_value = analogRead(Lower2Pot) ;
 
//
  while (digitalRead(PB1CC)==HIGH && LEDbrightness<255){
    LEDbrightness++                   ;
    analogWrite(LedPin, LEDbrightness);
    delay(10)                         ;
    Serial.print(LEDbrightness) ;
    Serial.print(", ")          ;
    Serial.print(Upper_value)   ;
    Serial.print(", ")          ;
    Serial.print(Lower1_value)  ;
    Serial.print(", ")          ;
    Serial.println(Lower2_value);
  }
//
  while (digitalRead(PB1CCW)==HIGH && LEDbrightness>0){
    LEDbrightness--                   ;
    analogWrite(LedPin, LEDbrightness);
    delay(10)                         ;
    Serial.print(LEDbrightness) ;
    Serial.print(", ")          ;
    Serial.print(Upper_value)   ;
    Serial.print(", ")          ;
    Serial.print(Lower1_value)  ;
    Serial.print(", ")          ;
    Serial.println(Lower2_value);
  }


 // Task 2: Displaying Data //

  if ((currentTime - prevTime) > interval_sample) {
    
    Serial.print(LEDbrightness) ;
    Serial.print(", ")          ;
    Serial.print(Upper_value)   ;
    Serial.print(", ")          ;
    Serial.print(Lower1_value)  ;
    Serial.print(", ")          ;
    Serial.println(Lower2_value);
    
    prevTime = currentTime ;
    
  }

}
