# Case Study #1 HW

## Problems
ให้ นศ. ดัดแปลงแก้ไขโปรแกรมที่แนบมานี้ให้ทำงานได้เร็วยิ่งขึ้น 
โดยในการแก้ไขใดๆ จะต้องมีคำอธิบายว่าแก้ไปเพราะอะไร นอกจากนี้หากมีการแก้หลาย version ต้องมีคำอธิบายของแต่ละ version และ version ที่ใหม่กว่าแก้ไขอะไรของ version เดิม เป็นต้น
ให้สังเกตปัญหาที่เกิดขึ้นในระหว่างทำงาน และให้ค้นคว้าหาสาเหตุของปัญหานั้นและวิธีการแก้ไข 
ประมวลข้อมูลทั้งหมดเพื่อเขียนสรุปส่งและนำเสนอหน้าห้องต่อไป

## Summition
- source code ของ version ที่ นศ คิดว่าเป็น version ที่ดีที่สุด
- สรุปสิ่งที่สังเกตพบ ปัญหา วิธีแก้ ลงในไฟล์ pdf และตั้งชื่อไฟล์โดยใช้รหัสของสมาชิกคั่นด้วยเครื่องหมาย _ เช่น 62010001_62010002_62010003.pdf **ให้เรียงลำดับรหัสจากน้อยไปหามากด้วย**
- ตัวแทนกลุ่มเป็นผู้ส่งเพียงผู้เดียวสำหรับกลุ่มหนึ่งๆ
- ใส่ชื่อสมาชิกกลุ่มในไฟล์ให้เรียบร้อย

## Installation
<!-- How to install this project -->

1. Clone this project
2. Download [problem01.dat](https://goedu.kmitl.ac.th/pluginfile.php/62913/mod_assign/introattachment/0/Problem01.rar?forcedownload=1) and put it in the Case Study #1 folder

## Issues and Resolves
<!-- Note some problem in Issues then note it here. the How to solve can be left blank 
     
Example

0. Problem: I am too handsome.

   Resolve: Check the mirror.
-->

Standard Result :
```
Summation result: 888701676
Time used: 31189ms
```

1. Problem:จำนวนข้อมูลมีความยาวมากเกินไปทำให้ต้องใช้เวลาในการคำนวณนานมาก

   Resolve:ทดลองแบ่ง เป็น 2 Thread คำนวณกันคนละครึ่ง เมื่อเสร็จ ค่านำค่าที่ได้ไปรวมกับตัวแปร sumglobal

     ``` 
     Summation result: 888701676
     Time used: 14392ms
     ```
2. Problem: ยิ่งเพิ่ม Thread ไปเรื่อย ๆ ก็จะยิ่งไวขึ้น
   Resolve: ทดลองเพิ่ม Thread ไปเรื่อย ๆ ความเร็วในการคำนวนก็เพิ่มขึ้นเรื่อย ๆ จนกระทั่ง Thread ที่ใช้เกินจำนวน Thread ที่มี ทำให้การทำงานช้าลง
   
   ``` 
   8 Thread
   Summation result: 888701676
   Time used: 4552ms

   12 Thread
   Summation result: 888701676
   Time used: 2647ms
   
   13 Thread
   Summation result: 888701676
   Time used: 3104ms
   ```
3. Problem: เนื่องจากทดลองเพิ่ม Thread ไปเรื่อยๆแล้วพบว่าจำนวน Thread ที่ประมวลผลได้เร็วที่สุดคือค่าที่เท่ากับจำนวน Thread ของ CPU 
   Resolve: ทำการดึงจำนวน Thread ของ CPU ที่มีมาช่วยแบ่งกันประมวลผล
   
   ``` 
   8 Thread
   Summation result: 888701676
   Time used: 4287ms
   ```
