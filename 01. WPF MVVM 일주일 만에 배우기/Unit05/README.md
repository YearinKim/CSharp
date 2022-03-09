

# 05장. 빛나게 만들기: 모양 사용자 정의

## 컨트롤 모양 변경

#### 템플릿

* 거의 모든 WPF 컨트롤은 Template 속성 존재
* 컨트롤에 새로운 모양을 제공하려면 새 ControlTemplate 인스턴스를 컨트롤 속성에 할당

```html
<Button Content="Press me">
    <Button.Template>
        <ControlTemplate TargetType="{x:Type Button}">
            <Ellipse Fill="GreenYellow" Width="100" Height="100"/>
        </ControlTemplate>
    </Button.Template>
</Button>
```

![image](https://user-images.githubusercontent.com/97888638/157414623-7129649b-ede7-4d1a-8fec-bfe1fb237c71.png)

* Button 컨트롤은 와전 한 기능을 갖추고 있으므로 사용자와 상호작용할 때 Click 이벤트나 MouseOver 이벤트 발생
* TargetType 속성은 ControlTemplate이 Button 컨트롤에 적용된다
* 대상 컨트롤에 대한 컨텍스트 정보 없이 정의
* 대상 유형을 나타내는 것이 필요

> 템플릿은 매우 강력하며 애니메이션을 비롯해 컨트롤에 거의 모든 모양을 제공할 수 있다
>
> 그러나 XAML을 수동으로 작성하는 것이 지루한 작업
>
> 훌륭한 결과를 얻으려면 비주얼 스튜디오에 포함된 Blend for Visual Studio를 사용하는 방법을 학습

<br/>

#### TemplateBinding

* ControlTemplate 정의 내부에서 템플릿 컨트롤의 속성을 참조하는 기능
* 템플릿에서 템플릿 컨트롤의 속성을 사용

```html
<Button Content="Press me">
    <Button.Template>
        <ControlTemplate TargetType="{x:Type Button}">
            <Grid>
                <Ellipse Fill="{TemplateBinding Background}" Width="100" Height="100"/>
                <Label Content="{TemplateBinding Content}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
            </Grid>
        </ControlTemplate>
    </Button.Template>
</Button>
```

![image](https://user-images.githubusercontent.com/97888638/157416120-5c8b17ee-1427-450b-b81a-add1ca2df16b.png)

<br/>

#### ItemPresenter

* ListBox 및 ComboBox 같은 Items 속성이 있는 목록 컨트롤도 템플릿으로 만들 수 있다
* 각 요소의 개별 모양을 변경하려면 ItemTemplate을 사용
* 컨트롤의 전체 레이아웃을 변경하려는 경우 해당 컨트롤의 Template 속성을 사용해 새로운 모양을 제공
* 목록 컨트롤에 대한 템플릿을 만들 때 항목의 실제 목록을 표시하려는 지점을 스스로 찾을 수 있을 것
* 해당 지점이 ItemsPresenter에 대한 것

<br/><br/>

## 리소스

* XAML에서 여러 컨트롤을 통해 일부 XAML을 공유가 필요 할 때마다 리소스가 애플리케이션 전체에서 같은 화면 또는 다른 호면에 있든 상관없이 응답
* 애플리케이션 내부의 모든 컨트롤은 문자열 키 사전인 Resources속성을 사용해 리소스를 저장
* 문자열 키를 제공하는 모든 리소스 객체를 추가
* 리소스를 저장하는 곳
  * **화면**: 페이지, 사용자 전의 컨트롤 또는 창과 같이 단일 화면으로 범위가 지정된 리소스
  * **애플리케이션**: App.xaml에 선언된 Application 요소와 같이 애플리케이션 전반에 걸쳐 사용되는 리소스

```html
<Application ...>
	<Apllciation.Resources>
    	<Button x:Key="button">Hello, world</Button>
        <SolidColorBrush x:Key="accentBrush" Color="Red"/>
    </Apllciation.Resources>
</Application>
```

<br/>

#### ResourceDictionaries

* 변환기, 브러시, 데이터 객체 또는 기술 객체, 컨트롤 템플릿, 데이터 템플릿 등 Application 요소 아래에 많은 리소스를 선언
* App.xaml 파일이 유지 보수가 어려울 수 있다
* 정돈된 개발자이기 때문에 리소스를 확실히 정돈하고 싶어하므로 리소스 사전이 만들어졌다

<br/><br/>

## 스타일

* 컨트롤의 모양을 스타일링하는 방법
* 스타일 컨트롤에 템플릿, 속성 및 리소스와 같은 여러 가지 방법

```html
<Application.Resources> 
    <Style x:Key="niceButton"
           TargetType="Button">
        <Setter Property="Height" Value="50"/>
        <Setter Property="Background">
            <Setter.Value>
                <LinearGradientBrush>
                    <GradientStop Color="Red"/>
                    <GradientStop Color="Yellow" Offset="1"/>
                </LinearGradientBrush>
            </Setter.Value>
        </Setter>
    </Style>
</Application.Resources> 
```

```html
<StackPanel Margin="1">
    <Button Style="{StaticResource niceButton}">
        A
    </Button>
    <Button>
        B
    </Button>
    <Button Style="{StaticResource niceButton}">
        C
    </Button>
    <Button Style="{StaticResource niceButton}">
        D
    </Button>
</StackPanel>
```



![image](https://user-images.githubusercontent.com/97888638/157419686-c1b84142-6a90-4e85-bc29-8881621f7f2f.png)

## 테마

* 디자이너와 올바르게 작업한다면 디자이너는 템플릿과 속성 값을 적용하는 암시적 및 명시적 스타일이 포함된 ResourceDictionary 파일을 제공
* 소규모 프로젝트의 경우와 같이 디자이너와 함께 작업하지 않을 경우 무료로 사용할 수 있는 테마가 존재
* https://wpfthemes.codeplex.com에서 확인

<br/><br/>

## 변형

* 컨트롤을 쉽게 크기 변경, 회전 또는 기울일 수 있다
* 모든 컨트롤에는 변형을 위해 사용 가능한 RenderTransform 및 LayoutTransform이 있다
* 변형에 필요한 XAML을 직접 작성할 수도 있지만 무의미
* 비주얼 스튜디오에서는 직관적인 방법으로 변형이 가능

![image](https://user-images.githubusercontent.com/97888638/157420729-48ed3504-d0d9-4eca-a570-ab1f0261d67d.png)

<br/><br/>

## 애니메이션

* 사태는 대부분의 상황에서 애니메이션을 생성하는 쉬운 방법
* 전황의 세부 사항이 아닌 최종 상태에 집중하기 때문에 애니메이션을 쉽게 유지 관리

