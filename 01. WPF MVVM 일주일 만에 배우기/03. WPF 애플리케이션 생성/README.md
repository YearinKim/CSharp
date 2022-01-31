## 개발자-디자이너 워크플로우

<img src="https://user-images.githubusercontent.com/92307342/142411771-d32f6838-fbe8-4400-a7d9-b7cffcb8f86c.png" width="50%">

## 편집기
#### Visual Stuido
* 컨트롤을 추가하고, XAML을 수동으로 편집
* 비즈니스 로직을 작성

#### Blend for Visual Studio 
* 컨트롤의 모양을 변경
* 애니메이션

<br/>
<br/>

## 컨트롤 추가
#### 방법
* 도구상자에서 컨트롤을 끌어다 놓는 방법
* 단순히 XAML 파일에 XML 요소를 추가하는 방법
```html
<Grid xmlns="...">
  <Button Content="Hello world" />
</Grid>
```

<br/>
<br/>

## 단순 컨트롤
#### 기본 컨트롤
```html
<TextBlock Text="TextBlock"/>
<TextBox Text="TextBox"/>
<ProgressBar Value="50" Width="60" Height="20"/>
<Slider Value="5" Width="60"/>
<PasswordBox Password="Secret"/>
```

#### 멀티미디어 컨트롤
* Image 컨트롤 & MediaElement
  * 컨트롤에 할당된 크기에 맞춰 자신의 내용을 크기 조절
  * 내용의 크기를 조절하는 방법은 지정하는 Stretch 속성을 제공
* Strech 속성
  * **Uniform**(기본 값): 필요에 따라 측면에 투명 여백을 남겨두고 이미지릐 크기가 비례해 조절
  * **Fill**: 이미지 비례적으로 크기가 조절되고, Image 컨트롤에 할당된 전체 공강을 채운다
```html
<Imgae Source="fleurs.jps> Height="50"/>
<MediaElement Source="ic09.wmv" Height="50"/>
```

#### 그리기 컨트롤
* 타원, 사각형 및 경로(Path) 컨트롤
  * **Fill**: 컨트롤의 내부를 칠하는 데 사용되는 브러시
  * **Strike**: 컨트롤의 윤곽을 그리는데 사용되는 브러시
  * **Stretch**: 크기를 조절할 때 컨트롤의 모양 크기 조절 방식
* Path 컨트롤은 매우 유연

#### 콘텐츠 컨트롤
* 콘텐츠를 가진 모든 컨트롤이 될 수 있다
```html
<Button Content="Un Button"/>
<ToggleButton Content="ToggleButton"/>
<CheckBox Content="CheckBox"/>
<RadioButton Content="RadioButton"/>
```
* **Content 속성**
  * Content 틀성을 사용해 할당
  * Content 요소를 사용하는 대신 하위 요소를 콘텐츠 컨트롤에 제공
```html
<Button Padding="5">
    <MediaElement Source="360.wmv"
                  Height="50"/>
</Button>
<Button Width="100">
    <CheckBox>
        <TextBlock Text="Avec un retour a la ligne"
                   TextWrapping="Wrap"/>
    </CheckBox>
</Button>
```
* 유연성을 제공
```html
<Border Background="Orange"
        CornerRadius="10"
        Padding="5">
    <Button Content="Un bouton"/>
</Border>
<Border Background="Blue"
        CornerRadius="10, 0, 10, 0"
        Padding="5">
    <Button Content="Un bouton"/>
</Border>
<ScrollViewer Height="100"
              Width="100"
              HorizontalScrollBarVisibility="Auto">
    <MediaElement Source="C:\Users\yearin.kim\Desktop\git\Study\src\01_MVVM\Example\media\360.wmv"
                  Stretch="None"/>
</ScrollViewer>
```
* ViewBox 컨트롤
  * 마치 사진처럼 모든 콘텐츠의 크기를 조정
  * 사용 가능한 너비와 높이에 맞게 화면을 신속하게 조정  
  <img src="https://user-images.githubusercontent.com/92307342/142861258-00c3a322-def6-457a-a779-a624515c0784.png" width="20%">

<br/>
<br/>

## 탐색
#### Frame 컨트롤
* 웹 브라우저와 웹 페이지의 페이지  
<img src="https://user-images.githubusercontent.com/92307342/142418669-9120ac6f-2a07-4f9d-a682-39cd13ae210e.png" width="70%" height="70%">

#### Page
* 사용자 정의 컨트롤의 하위 클래스이므로 상용자 정의 컨트롤로 생각할 수 있다
* 애플리케이션에 필요한 화면만큼의 페이지를 생성한 다음 페이지 브라우저로 사용할 Frame 컨트롤을 추가
```html
<Page x:Class="..." Title="...">
  <Gird>
    ...
  </Gird>
</Page>
```

#### Source 속성
* [-페이지 이름 앞에 "/"를 잊지 않도록 한다-]
```html
<Fram Source="/Welcom.xaml">
</Fram>
```

<br/>
<br/>

## XAML 이해
#### XAML 네임스페이스
* 루트 요소에 적용된 여러 xmlns 특성
```html
<StackPanel xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Button x:Name="someButton">Hello</Button>
</StackPanel>
```
* C# 코드의 using키워드와 같이 XAML 네임스페이스의 사용을 선언

#### 객체 생성
* 외관 묘사 도구로 사용
```csharp
using BusinessLogic;
new Car();
```
```html
<Label xmlns:bl="clr-namespace:BusinessLogic">
  <bl:Car />
</Label>
```

#### 속성 정의
* XAML에서 생성한 객체의 속성에 값을 쉽게 할당
* 동등한 코드
```csharp
using BusinessLogic;
    
var c = new Car();
c.Speed = 100;
c.Color = Colors.Red;
```
```html
<Label xmlns:bl="namespace:BusinessLogic">
  <bl:Car Speed="100" Color="Red" />
</Label>
```
#### XAML 파일에서 선언한 객체를 코드 비하인드에서 조작하거나 단순히 XAML 요소 일부를 다른 XAML 요소에 참조하기를 원한다면 x:Name 특성을 추가 가능

<br/>
<br/>

## 이벤트
#### 이벤트를 선언하며 속성과 마찬가지로 XAML의 특성으로 사용 가능

#### 단순히 특성에 코드 비하인드 메소드명을 제공
```html
<Button Click="Greet"/>
```
```csharp
private void Greet(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Hello");
}
```

<br/>
<br/>

## 레이아웃
#### 화면이 크기 조절되지 않는 이유
* 루트 커트롤이 Canvas: 끌어다 놓기 동작을 너비, 높이, 왼족, 및 상단
* 푸트 컨트롤이 Grid: HorizontalAlignment 및 VerticalAligment 컨트롤 속성 변환
* **Panel** 컨트롤의 사용하여 해결

#### 크기 할당
* 컨트롤의 최종 너비를 계산  

<img src="https://user-images.githubusercontent.com/92307342/143582541-9f99f473-45ba-4798-a4ba-b07c20936907.png" width="50%" height="50%">
* 컨트롤의 자식, 부모에의해 제약된 ㅣ크기를 조회하고 마지막에 컨트롤 자체의 Width, MinWidth 또는 MaxWidth 속성을 확인
* **부모 제한 크기**는 자식 필수 크기보다 우선, Width 속성은 부모나 자식의 값보다 우선
```html
<Canvas Width="50" Height="50" Nackground="Orange">
  <Button Content="Hello world" Margin="5" />
</Canvas>
```
* Canvas 컨트롤은 자식 컨트롤 크기를 제한하지 않고 Button 컨트롤에 Width 속성이 없으므로 Button 컨트롤에 'Hello World' 텍스트 전체를 표시하는 데 필요한 크기가 할당   
<img src="https://user-images.githubusercontent.com/92307342/143583801-859133fb-9c23-41fe-8eec-33ed7297f190.png" width="20%" height="20%">
* 패널 컨트롤

| 컨트롤      | 크기 강제 | 사용 평의 |
| ----------- | --------- | --------- |
| Canvas      | No        | 디자인 뷰 |
| DockPanel   | Yes       | XAML      |
| Grid        | Yes       | 디자인 뷰 |
| StackPanel  | Yes       | XAML      |
| UniformGrid | Yes       | XAML      |
| WrapPanel   | Yes       | XAML      |

<img src="https://user-images.githubusercontent.com/92307342/143586462-6c22d0e6-7185-432f-a748-f64a9cc3d83e.png" width="70%" height="70%">