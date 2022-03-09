# 04장. WPF 애플리케이션에서 데이터 관리

## 데이터 바인딩

* UI를 데이터와 동기화된 상태로 유지하는 아주 적은 양의 코드를 작성
* 애플리케이션의 빠른 작성 속도뿐만 아니라 애플릿케이션을 유지 보수시 작업이 훨씬 적다
* 컨트롤의 속성에 변수를 할당 가능
* 사용자가 컨트롤과 상호작용해 속성이 변경되고 이벤트를 처리하고 원래 변수에 수정된 데이터를 사용

![image](https://user-images.githubusercontent.com/97888638/156166928-e0f31ac9-c8dd-472d-9da7-c3877098a228.png)

```html
<TextBox Text = "{Binding Speed, ElemnetName  = c }"/>
```

* Binding 키워드 다은메 연결할 데이터 객체 속성의 이름을 쓰면 데이터 객체의 위치를 지정
* ElementName 구문을 사용해 데이터 객체가 명명된 요소

```html
<TextBox Text = "{Binding Seed}"/>
```

#### 바인딩 예제

```html
<StackPanel Orientation="Vertical"
            Margin="5">
    <Label Content="바인딩 예제"/>
    <StackPanel>
        <Slider Maximum="100"
                Value="10"
                x:Name="slider"/>
        <ProgressBar
            Value="{Binding Value, ElementName=slider}"/>
        <TextBox
            Text="{Binding Value, ElementName=slider}"/>
    </StackPanel>
</StackPanel>
```

#### 바인딩 모드

* 기본적으로 데이터 바인딩 모드는 바인딩할 컨트롤 속성에 따라 다름

| 모드           | 대상 변경 | 갑 변경 |
| -------------- | --------- | ------- |
| TwoWay         | Yes       | Yes     |
| OneWay         | No        | Yes     |
| OneWayToSource | Yes       | No      |
| OntTime        | No        | No      |

> OneWayToSource 및 OneTime은 거의 사용되지 않는다.

#### 바인딩 오류

* WPF 애플리케이션에서 데이터 바인딩은 매우 간결한 구문 덕분에 개발 및 유지 보수의 실시간 보호기
* 오류는 너무 빨리 지나치는 경우가 많음
* 런타임에 처려되지 않은 예외(unhandled exception)로 나타남으로 놓치기 쉽다
* null이나 잘못된 값이 그냥 무시될 것이고, 일반적인 애플리케이션의 요구 사항의 일부일 수 있으므로 무시하는 것이 원하는 것일 수 있음
* 오류를 확인하고 싶다면
  * 애플리케이션을 디버그 모드로 실행
  * 수동으로 화면을 이동
  * 비주얼 스튜디오의 디버그 출력 창에서 System.Data Error로 시작하는 줄을 살펴본다



<br/><br/>

## DataContext

* 데이터 중심 애플리케이션의 화면에서 시각적으로 그룹화된 대부분의 컨트롤은 동일한 데이터 객체의 데이터를 사용
* 바인딩에 대해 작성한 XAML을 단순화하기 위한 방법
  * **DRY** 코딩 습관: 반복적인 것을 하지 않는다
* 모든 객체 유형을 **DataContext**에 할당 가능
* 바인딩 식에 소스에 대헌 언급이 없으면 소스는 컨트롤의 **DataContext 속성**으로 간주

> DataContext는 XAML 개발자가 충분히 사용하지 못하는 훌륭한 XAML 시간 절약기 중 하나



<br/><br/>

## 변환기

* **XAML 엔진**은 데이터 바인딩 시 객체 유형을 변환하는 훌륭한 작업을 수행
* **변환기**는 **IValueConverter** 인터페이스를 상속해 작성하는 단순한 클래스
* 해당 인터페이스를 사용하려면 두 가지 메소드 작성이 필요
  * **Convert**는 '표준' 메소드고
  * **ConvertBack**은 양방향 데이터 바인딩에 사용

```csharp
namespace Maths:{
    public class TwiceConverter : IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultereInfo culture)
        {
            return ((int)value)*2;
        }
        // 빈 ConverBack 메소드가 여기에 들어가게 된다.
    }
}
```

```html
<Page xmlns:c="clr-namespce:Maths">
    <Page.Resources>
        <c:TwiceConverter x:Key="twiceConv"/>
    </Page.Resources>
    <TextBlock Value="{Binding Speed, Converter={StaticResource twiceConv}}"/>
</Page>
```



<br/><br/>

## 목록 컨트롤을 사용하는 컬렉션 표시

* 종종 사용자가 데이터의 컬렛녕을 확인하고 업데이트할 수 있게 해야 한다
* 데이터 컬렉션은 쉽고 단순
* 모든 목록 컨트롤에는 **IEnumerable**로 형식화된 **ItemsSource 속성**

```csharp
var cars = new List<Car>();
for (int i = 0; i < 10; i++)
{
    cars.Add(new Car()
    {
        Speed = i * 10
    });
}
this.DataContext = cars;
```

```html
<ListBox ItemsSource="{Binding}"/>
```

![image-20220309174927317](C:\Users\yearin.kim\AppData\Roaming\Typora\typora-user-images\image-20220309174927317.png)

<br/><br/>

## 목록 컨트롤 사용자 정의

* ListBox 컨트롤은 표시할 자동차 속성을 제공하는 Display MemberPath 속성
* 하나의 속성만을 텍스트로만 표시하고 또한 다른 목록 컨트롤에는 동작하지 않으므로 너무 제한적
* 모든 모록 컨트롤에는 항목을 표시하는 방법을 사용자 정의할 수 있는 다음고 같은 속성
  * ItemPanel은 요소를 배치하는 방법을 설명
  * ItemTemplate은 각 요소에 대해 반복이 필요한 템플릿을 제공
  * ItemContainerStyle은 항목을 선택하거나 마우스를 올릴 때의 동작 방법을 설명
  * Template은 컨트롤 자체를 렌더링하는 방법을 설명
* ItemTemplate 속성은 각 목록 항목에 대해 반복되는 DataTemplate
* DataTempalte 내부 요소는 데이터 바인딩식을 사용해 해당 속성을 기본 항목 속성에 연결
* 실제로 DataTempate의 DataContext는 표시되는 항목

```html
<ListBox ItemsSource="{Binding}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding Speed}"/>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
<ListBox ItemsSource="{Binding}">
    <ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel>
                <TextBlock Text="Speed"/>
                <TextBlock Text="{Binding Speed}"/>
                <Slider Value="{Binding Speed}" Maximum="100"/>
                <TextBlock Text="Color"/>
                <Border Height="10">
                    <Border.Background>
                        <SolidColorBrush Color="{Binding Color}"/>
                    </Border.Background>
                </Border>
                <TextBox Text="{Binding Color}"/>
            </StackPanel>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

![image](https://user-images.githubusercontent.com/97888638/157409577-dbb1c667-6561-42a6-a396-becf5db9e97e.png)

<br/><br/>

## INotifyPropertyChanged

* 컨트롤을 통해 사용자가 속성을 업데이트하면 동일한 속성에 바인딩된 다른 컨트롤이 작성된 코드가 정혀 없어도 업데이트
* 코드 자체로 인해 속성이 변경되면 해당 속성에 바인딩된 컨트롤이 업데이트 X
* 이런 종류의 시나리오가 작동하려면 속성이 변경되기 시작할 때 이벤트를 발생
* 속성 변경의 이벤트는 INotifyPropertyChanged 인터페이스
* **데이터 바인딩된 UI가 자동으로 업데이트되는 동안 데이터 객체를 업데이트하는 데 중점을 둔 깨끗한 코드를 작성**

```csharp
using System.ComponentModel;

public class Notifier : INotifyPropertyChanbed
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

> 대부분의 MVVM 프레임워크는 해당 클래스와 같은 기능을 제공하고 몇 가지 똑똑한 방법으로 이벤트를 발생시키는 도우미까지도 제공

<br/><br/>

## INotifyCollectionChanged

* 컬렉션에서 추가, 제거 및 변경을 알리 수 있다
* WPF 목록 컨트롤은 해당 인터페이스를 검색하고 고려해 사용자 인터페이스를 세부적으로 업데이트
* 직접 인터페이스를 구현할 필요조차 없다
* ObservabelCollection<T>를 구현하다는 점을 제외하고 List<T>와 같은 클래스 제공
* List<T> 대신 ObservableCollection<T>를 사용하면 세밀한 UI 업데이트

