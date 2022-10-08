unsigned long last_time;

void setup() {
  Serial.begin(9600);
  // Serial.println("Hello");
  // // delay(1000); // wait for 1 sec
  // // Serial.println("1 sec");
  // // delay(2000); // wait for 2 sec
  // // Serial.println("2 sec");
  // delayMicroseconds(1000); // wait for 1 millisecond
}

void loop() {
  // if (millis() - last_time == 1000) { //(unsigned long)23 * 24 * 60 * 60 * 100) {//Пишем (unsigned long) или (long) перед умножением, чтобы программатор выделил нужное количество памяти для проведения операции! (для работы с большими числами)
  //   last_time = millis();
  //   Serial.println("kek");
  // }

  if (round(millis() / 1000) % 2 == 0)
    Serial.println("smth 1");
  else
    Serial.println("smth 2");
}