   M S B A M L   `   `   `  ���� G  CCpuBenchmark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CpuBenchmarkCpuBenchmark  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     CpuBenchmark.ResultWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:CpuBenchmark     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     8
syncfusion!http://schemas.syncfusion.com/wpf       � Title$  ResultWindow��$	��457��$	��800�� � 
ResizeMode$ NoResize=�.��� .+��� -    ��Name$ sparklineLabelRect��$��34��$��
10,18,10,0q����	#FF21719E$	��Top=����	#FF4894EE�� -    ��Name$ 	specLabel��$��Your results:��$��29��$��10,23,434,0q�$	��Top=�$��16(�$
��Bold"����	#FFEEEEEE#  LiveCharts.Wpf.CartesianChart  -     Name$ caretesianChart��&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�$��10,57,10,181q�   Series �� *seriesCollection+   AxisY   LiveCharts.Wpf.Axis     Title$ Time taken [s]��	   AxisX	   $
 Date��
   Labels
 �� *dates+�� -    ��Name$ returnButton��$��RETURN��$��559,355,30,24q�$��22(����	#FF3A75D4���	#FF4894EE$
��Bold"�
�������$��3,3,3,3q� � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 7���� -   $ comparisonLabel��$(��"You did better than  00% entries !��$
��Left=�$��82��$��
51,297,0,0q�$	��Top=�$	��464��$��24(�$
��Bold"�