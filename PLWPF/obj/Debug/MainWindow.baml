   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  Driver application��5   	   $	��450��6$   $	��800��61    � 	Resources 5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�   &	        �� 5
   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 15��6!   
�������$��1q�6F   $ 2q�6Z   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � ��5   
   �� 5       �� ImageSource$ Images/Cars_50.jpg��6   	 j� Stretch$	 UniformToFill=�6:   
 � ColumnDefinitions
 5   
   �� 5      $
��250* �6   �� 5      $
��545* �6   .+�5   
   � -   5        $��grid_button��5      $��0��6"    � RowDefinitions 5      �� 5       $��* �6    �� 5!      $��* �6    �� 5"      $��* �6    �� 5#      $��* �6    .+�5%      �� ��5&      �� 5'      .R�5(      �� $��Show_DataSource��5*   !   -   5        $��0��5(   !   $��10q�6.   $��Show_DataSource��5)   !   $��20(�5+   !   6/    �� Triggers 5,      �� 5-       �� Value$ Visible��6j    �� Binding 6*   ��  �� ElementName$ ShowDataSource�� �� Path$ 
Visibility�.a�5.   "   ��  �� 
TargetName$ Show_DataSource��6)   # [  6W    � ��5/      �� 50      $ Hidden��6j    6*   �� $ ShowDataSource��$ 
Visibility�.a�51   "   �� $ Show_DataSource��6)    6W   Z�  � ��52      54      56      �� 57      $��1��6   ��58      �� 59      .R�5:      �� $��
Add_Tester��5<      -   5        $��10q�5:   "   $��
Add Tester��5;      $��20(�5=      6'    5>      �� 5?      $ Visible��6e    6*   �� $ 	NewTester��$ 
Visibility�.a�5@   "   �� $ 
Add_Tester��6)   # [  6R    � ��5A      �� 5B      $ Hidden��6e    6*   �� $ 	NewTester��$ 
Visibility�.a�5C   "   �� $ 
Add_Tester��6)    6R   Z�  � ��5D      5F      5H      �� 5I      $��2��6   ��5J      �� 5K      .R�5L      �� $��Add_Trainee��5N   !   -   5        $��2��5L   !   $��10q�6.   $��Add Trainee��5M   !   $��20(�5O   !   6/    5P      �� 5Q      $ Visible��6f    6*   �� $ 
NewTrainee��$ 
Visibility�.a�5R   "   �� $ Add_Trainee��6)   # [  6S    � ��5S      �� 5T      $ Hidden��6f    6*   �� $ 
NewTrainee��$ 
Visibility�.a�5U   "   �� $ Add_Trainee��6)    6S   Z�  � ��5V      5X      5Z      �� 5[      $��3��6   ��5\      �� 5]      .R�5^      �� $��Add_Test��5`   !   -   5        $��3��5^   !   $��10q�6.   $��Add Test��5_   !   $��20(�5a   !   6/    5b      �� 5c      $ Visible��6c    6*   �� $ NewTest��$ 
Visibility�.a�5d   "   �� $ Add_Test��6)   # [  6P    � ��5e      �� 5f      $ Hidden��6c    6*   �� $ NewTest��$ 
Visibility�.a�5g   "   �� $ Add_Test��6)    6P   Z�  � ��5h      5j      5l      5m      �� 5o   
   $��Images/Sun.png��6   $��1��6(   $��395,10,10,270q�68      PLWPF.Add_tester  5p   
   -   5          Name$ 	NewTester��5p   /   $y�Hidden=�6   $
��Left=�6B   $��
50,15,0,15q�6]   $��Stretch=�6q   $
��auto��6�   $��1��6�      PLWPF.Add_trainee  5q   
   -   5          Name$ 
NewTrainee��5q   0   $y�Hidden=�6   $
��Left=�6D   $��
50,15,0,15q�6_   $��Stretch=�6s   $
��auto��6�   $��1��6�      PLWPF.Add_test  5r   
   -   5          Name$ NewTest��5r   -   $y�Hidden=�6   $
��Left=�6>   $��
50,15,0,15q�6Y   $��Stretch=�6m   $
��auto��6�   $��1��6�      PLWPF.Show_dataSource  5s   
   -	   5          Name$ ShowDataSource��5s   4   $y�Hidden=�6    $
��Left=�6L   $��0,0,0,0q�6g   $��Stretch=�6x   $
��auto��6�   $��1��6�   5t      5u      