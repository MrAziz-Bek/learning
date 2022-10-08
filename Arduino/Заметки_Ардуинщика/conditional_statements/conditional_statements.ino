byte val;

void setup() {
  // boolean val = 1;
  // if (val == 1) {
  //   // if val equals 1 or true, then do something
  // }
  // int sensor;
  // if (sensor > 300) {
  //   // statements...
  // }
  // if (sensor < 200 || sensor > 400) {
  //   // statements...
  // } else {
  //   // statements...
  // }

  Serial.begin(9600);
}

void loop() {
  if (Serial.available()) {
    val = Serial.parseInt();
    // if (val == 1) {
    //   Serial.println("You entered 1");
    // } else if (val == 2) {
    //   Serial.println("You entered 2");
    // } else if (val == 3) {
    //   Serial.println("You entered 3");
    // } else {
    //   Serial.println("Missed!");
    // }
    switch (val) {
      case 1:
        Serial.println("You entered 1");
        break;
      case 2:
        Serial.println("You entered 2");
        break;
      case 3:
        Serial.println("You entered 3");
        break;
      default: Serial.println("Missed");
    }
  }
}