# 06장. WPF MVVM 패턴

## MVC

* **뷰**: 순수 XAML
* **모델**: INotifyPropertyChanged 및 INotifyCollectionChanged를 구현한 클래스
* **컨트롤러**: 명령, 트리거, 관련 이벤트, NavigationService

<br/><br/>

## MVVM

![image](https://user-images.githubusercontent.com/97888638/157422091-a5b43d6f-2629-4afa-8d83-8babddb09380.png)

* 하나의 뷰에 대한 메소드로 속성 및 액션을 사용해 데이터를 노출
* 뷰를 참조하지 않아야 하지만 뷰에 크게 의존
* 다른 DataModel 혼합을 허용하거나 비동기 호출의 복잡성을 숨길 수 있다
* 단위 테스트를 쉽게 할 수 있다
* INotifyPropertyChanged를 구현

<br/><br/>

## 권장하는 단계(단순)

* ViewModel을 생성
* ViewModel이 노출해야 하는 속성 찾기
* 알림 속성 코딩
* ViewModel을 View의 DataContext로 사용
* View를 ViewModel에 데이터 바인딩
* 기능적 논리를 코딩

<br/>

#### ViewModel 생성

* 단순히 클래스
* 각 화면당 하나씩

#### ViewModel이 노출해야 하는 속성 찾기

* 생성을 원하는 뷰
* 모든 사용자 입력이나 출력에 대해 ViewModel에 속성을 추가

#### 코드 알림 속성

* ViewModel에 추가하는 속성은 알림 속성이 있어야 한다
* 알림 속성은 공간을 많이 차지하지만 기능 코드는 포함하지 않는다

#### View의 DataContext로 ViewModel 사용

* 여러 가지 방법 존재
* 가장 쉬운 두가지 방법은 XAML 사용 및 코드 비하인드 사용