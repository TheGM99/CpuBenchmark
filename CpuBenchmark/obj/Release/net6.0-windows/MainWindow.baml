   M S B A M L   `   `   `  ���� G  CCpuBenchmark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CpuBenchmarkCpuBenchmark      CpuBenchmark.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:CpuBenchmark     -     �Name$  MainWindow1�� � Title$ CPU Benchmark��$	��595��$	��800�� � 
ResizeMode$ NoResize=�.��� .+��� -    ��Name$ specRectangle��$��10,384,10,6q����	#FF706868���	#FFDCCFCF�� -   $ specLabelRect��$��44��$��10,331,10,0q����	#FF21719E$	��Top=����	#FF4894EE�� -    ��Name$ 	specLabel��$��System Specifications��$��44��$��10,331,434,0q�$	��Top=�$��22(�$
��Bold"����	#FFEEEEEE�� -   $ 
titleLabel��$��
Your Time:��$��58��$��299,55,266,0q�$	��Top=�$��36(�$
��Bold"��� -    ��Name$ compareButton��$��Compare your results��$��546,265,10,0q�$	��Top=�$��50��$��22(����	#FF3A75D4���	#FF4894EE$
��Bold"�
�������$��3,3,3,3q�${�False�� � 	Resources  �� 
TargetType �� Property	 �� Value��%9   '��       �� " ��.���  �@��CornerRadius$	 5��� -   
 �Name$
 progBar��$��34��$��216,150,216,0q�$	��Top=� � IsIndeterminate$
 True���� -   $ 
errorLabel��$!��if something wrong msg here��$��216,181,216,0q�$	��Top=�$y�	Collapsed=��� -	   $ osLabel��$��Operating system:��$
��Left=�$��
25,438,0,0q�$	��Top=�$��16(��� -
   $ osText��$��Operating system here��$
��Left=�$��168,438,0,0q�$	��Top=�$��16(��� -   $ cpuLabel��$
��CPU:��$
��Left=�$��
25,469,0,0q�$	��Top=�$��16(��� -   $ cpuText��$��Cpu here��$
��Left=�$��
73,469,0,0q�$	��Top=�$��16(��� -   $ memLabel��$��Memory (RAM):��$
��Left=�$��
25,496,0,0q�$	��Top=�$��16(��� -   $ memText��$��Memory here��$
��Left=�$��151,496,0,0q�$	��Top=�$��16(��� -   $ pcLabel��$��PC Name:��$
��Left=�$��
25,407,0,0q�$	��Top=�$��16(��� -   $ pcText��$��Pc name here��$
��Left=�$��104,407,0,0q�$	��Top=�$��16(��� -   $ scoreTextSingle��$
��0000��$��Center=�$��	0,118,0,0q�$	��Top=�$��36(�$
��Bold"�$y�	Collapsed=��� -   $ scoreTextAll��$
��0000��$��Center=�$��	0,176,0,0q�$	��Top=�$��36(�$
��Bold"�$y�	Collapsed=��� -   $ scoreLabelSingle��$��Single Thread:��$
��Left=�$��
85,127,0,0q�$	��Top=�$��24(�$
��Bold"�$y�	Collapsed=��� -   $ scoreLabelAll��$��Multiple Threads:��$
��Left=�$��
85,184,0,0q�$	��Top=�$��24(�$
��Bold"�$y�	Collapsed=��� -   $ 	runButton��$��	Run Again��$��
11,0,623,0q�$��Center=�$��50��$��22(����	#FF3A75D4���	#FF4894EE$
��Bold"�
�������$��3,3,3,3q�${�False�� ��%9   '��       �� " ��.���  �@��CornerRadius$	 5��