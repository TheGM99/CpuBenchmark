   M S B A M L   `   `   `  ����G  CCpuBenchmark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CpuBenchmarkCpuBenchmark  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       CpuBenchmark.ResultWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CpuBenchmark     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   8
syncfusion!http://schemas.syncfusion.com/wpf     5   	     � Title$  ResultWindow��5
   	   $	��457��6   $	��800��6+    � 
ResizeMode$ NoResize=�67   .��5      � .+�5   
   �� -   5         ��Name$ sparklineLabelRect��5      $��34��60   $��
10,18,10,0q�6<   ���	#FF21719E$	��Top=�6c   ���	#FF4894EE6{   �� 5   
   -   5         ��Name$ 	specLabel��5      $��Your results:��6#   $��29��6;   $��10,23,434,0q�6G   $	��Top=�6\   $��16(�6t   $
��Bold"�6�   ���	#FFEEEEEE6�   #  LiveCharts.Wpf.CartesianChart  5   
   -   5          Name$ caretesianChart��5      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6Z   $��10,57,10,181q�6q      Series 66   �� *seriesCollection+   AxisY 5        LiveCharts.Wpf.Axis     Title$ Time taken [s]��6   64   	   AxisX	 5        $
 Date��6   
   Labels
 6(   �� *dates+6C   5      �� 5   
   -   5         ��Name$ returnButton��5      $��RETURN��6'   $��559,355,30,24q�68   $��22(�6O   ���	#FF3A75D4���	#FF4894EE$
��Bold"�6�   
�������$��3,3,3,3q�6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 7��65   5      5      5      �� 5   
   -   5        $ comparisonLabel��5      $(��"You did better than  00% entries !��6)   $
��Left=�6V   $��82��6q   $��
51,297,0,0q�6}   $	��Top=�6�   $	��464��6�   $��24(�6�   $
��Bold"�6�   5       5!      