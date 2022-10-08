void setup()
{
   Serial.begin(9600);
  // Serial.print("Hello, World");
  // Serial.println("Hi, how ar u");

  // String mystring = "smth";
  // Serial.println(mystring);

  // float pi = 3.1415926535;
  // Serial.println(pi, 3);

  // int newVal = 1234;
  // Serial.println(newVal, DEC);
  // Serial.println(newVal, HEX);
  // Serial.println(newVal, OCT);
  // Serial.println(newVal, BIN);
}

void loop()
{
  if (Serial.available() > 0) {
    int in_data = Serial.parseInt();
    Serial.println((int)in_data);
  }
}