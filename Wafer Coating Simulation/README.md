# 개요
![image](https://user-images.githubusercontent.com/78133537/142416356-b5d71df6-37a1-4ec8-9d7c-3f2a4909c7c5.png)


### WaferLineLib

Wafer와 WaferLine을 정의한 클래스 라이브러리

WaferLine의 상태가 바뀔 때 이벤트로 통보하기위해 이벤트 인자 클래스와 이벤트 핸들러 대리자를 정의

![image](https://user-images.githubusercontent.com/78133537/142417149-16483583-72c4-4e9a-a224-b0aab593de08.png)

<br><br>

### WaferLineControlLib

Wafer와 WaferLine을 시각화하는 사용자 정의 컨트롤 라이브러리

화면 깜빡임을 줄이기 위한 DoubleBuffer 속성을 설정한 DPanel 클래스와 Wafer를 표현할 WaferPanel, WaferLine을 표현할 WaferLineControl을 정의

<br><br>

### WaferLineCommLib

공장설비와 중앙관제 사이의 통신을 정의한 클래스 라이브러리

FactoryClient, FactoryServer : 중앙관제를 통해 공장설비를 제어

ControlClient, ControlServer : 공장설비의 현재 상태를 중앙관제에 제공

MyNetwork : 자신의 IP 주소 목록을 제공

![image](https://user-images.githubusercontent.com/78133537/142418426-f5bcc595-23cb-44fb-8b74-5907840d10de.png)

---

### WaferLine 공장 설비 시뮬레이션

MainForn과 WaferLineForm 및 통신을 담당하는 Manager로 구성

MainForm에서는 Line을 추가 및 기본적인 공장의 상황을 모니터링 가능

특정 Line 관리 시 WaferLineForm을 띄워서 Wafer추가, 코팅액 추가를 비롯하여 WaferLine 제어 가능

WaferLineForm은 WaferLineControl을 배치하여 하나의 WaferLine을 제어하는 역할을 담당

Manager를 통해 공장설비 상황을 중앙관제에 전달하며, 중앙관제에서 제어 메시지를 수신하면 이벤트 처리로 이를 알려 WaferLine을 제어할 수 있게 도와줌.

![image](https://user-images.githubusercontent.com/78133537/142419554-13609022-e5f2-4513-85eb-969b367fec5d.png)

---

### 중앙 관제

CentralForm 하나로 구성하고, WaferLineCommLib을 참조하여 사용

CentralForm에서는 WaferLine 공장설비와 소켓으로 연결하여 공장설비 상황을 모니터링

![image](https://user-images.githubusercontent.com/78133537/142420837-f1f605eb-2bb1-4b0e-9791-bb88f5782139.png)








