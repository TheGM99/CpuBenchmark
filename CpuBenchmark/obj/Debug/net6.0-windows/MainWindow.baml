   M S B A M L   `   `   `  ����G  CCpuBenchmark, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CpuBenchmarkCpuBenchmark  5   	       CpuBenchmark.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CpuBenchmark     5   	   -   5          �Name$  MainWindow1��5   	    � Title$ CPU Benchmark��5   	   $	��595��6   $	��800��6,    � 
ResizeMode$ NoResize=�68   .��5	      � .+�5
   
   �� -   5         ��Name$ specRectangle��5
      $��10,384,10,6q�6+   ���	#FF706868���	#FFDCCFCF6S   �� 5   
   -   5        $ specLabelRect��5      $��44��6+   $��10,331,10,0q�67   ���	#FF21719E$	��Top=�6_   ���	#FF4894EE6w   �� 5   
   -   5         ��Name$ 	specLabel��5      $��System Specifications��6#   $��44��6C   $��10,331,434,0q�6O   $	��Top=�6e   $��22(�6}   $
��Bold"�6�   ���	#FFEEEEEE6�   �� 5   
   -   5        $ 
titleLabel��5      $��
Your Time:��6$   $��58��69   $��299,55,266,0q�6E   $	��Top=�6[   $��36(�6s   $
��Bold"�6�   �� 5   
   -   5         ��Name$ compareButton��5      $��Compare your results��6(   $��546,265,10,0q�6G   $	��Top=�6]   $��50��6u   $��22(�6�   ���	#FF3A75D4���	#FF4894EE$
��Bold"�6�   
�������$��3,3,3,3q�6�   ${�False��6�    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$	 5��65   5      5      5      � 5   
   -   5        
 �Name$
 progBar��5      $��34��6'   $��216,150,216,0q�63   $	��Top=�6J    � IsIndeterminate$
 True��6b   �� 5   
   -   5        $ 
errorLabel��5      $!��if something wrong msg here��6$   $��216,181,216,0q�6J   $	��Top=�6a   $y�	Collapsed=�6y   �� 5   
   -	   5        $ osLabel��5      $��Operating system:��6!   $
��Left=�6=   $��
25,438,0,0q�6X   $	��Top=�6l   $��16(�6�   �� 5   
   -
   5        $ osText��5      $��Operating system here��6    $
��Left=�6@   $��168,438,0,0q�6[   $	��Top=�6p   $��16(�6�   �� 5   
   -   5        $ cpuLabel��5      $
��CPU:��6"   $
��Left=�61   $��
25,469,0,0q�6L   $	��Top=�6`   $��16(�6x   �� 5   
   -   5        $ cpuText��5      $��Cpu here��6!   $
��Left=�64   $��
73,469,0,0q�6O   $	��Top=�6c   $��16(�6{   �� 5   
   -   5        $ memLabel��5      $��Memory (RAM):��6"   $
��Left=�6:   $��
25,496,0,0q�6U   $	��Top=�6i   $��16(�6�   �� 5   
   -   5        $ memText��5      $��Memory here��6!   $
��Left=�67   $��151,496,0,0q�6R   $	��Top=�6g   $��16(�6   �� 5   
   -   5        $ pcLabel��5      $��PC Name:��6!   $
��Left=�64   $��
25,407,0,0q�6O   $	��Top=�6c   $��16(�6{   �� 5   
   -   5        $ pcText��5      $��Pc name here��6    $
��Left=�67   $��104,407,0,0q�6R   $	��Top=�6g   $��16(�6   �� 5   
   -   5        $ scoreTextSingle��5      $
��0000��6)   $��Center=�68   $��	0,118,0,0q�6U   $	��Top=�6h   $��36(�6�   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5    
   -   5        $ scoreTextAll��5       $
��0000��6&   $��Center=�65   $��	0,176,0,0q�6R   $	��Top=�6e   $��36(�6}   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5!   
   -   5        $ scoreLabelSingle��5!      $��Single Thread:��6*   $
��Left=�6C   $��
85,127,0,0q�6^   $	��Top=�6r   $��24(�6�   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5"   
   -   5        $ scoreLabelAll��5"      $��Multiple Threads:��6'   $
��Left=�6C   $��
85,184,0,0q�6^   $	��Top=�6r   $��24(�6�   $
��Bold"�6�   $y�	Collapsed=�6�   �� 5#   
   -   5        $ 	runButton��5#      $��	Run Again��6$   $��
11,0,623,0q�68   $��Center=�6L   $��50��6g   $��22(�6s   ���	#FF3A75D4���	#FF4894EE$
��Bold"�6�   
�������$��3,3,3,3q�6�   ${�False��6�    5$      ��%^   '��       �� 5%      " ��6   .�5&      ��  �@��CornerRadius$	 5��65   5'      5(      5)      5+      5,      