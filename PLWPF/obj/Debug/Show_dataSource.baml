   M S B A M L   `   `   `  ����=  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      @ <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF 5         PLWPF.Show_dataSource   5      %myBEclr-namespace:BE;assembly=BE  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      6sys&clr-namespace:System;assembly=mscorlib     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:PLWPF     5      $��1q�5
   7   
�������
����iA�  � 	Resources  5        PLWPF.bool2dimListDays   myConverterList��%   &	          5   
   6!   5      .��5      � -   5        $��mainGrid��5      
�������$��3q�6.    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��269* �6   .+�5   
   �� -   5        $��testErTrain��5       �� SelectedIndex$ 0��6&   $��center=�68   $��Center=�6\   $��Stretch=�6~   $��20��6�   $��Center=�6�   $��3,0,3,0q�6�   .@�5      �� $��Select��6   $��Center=�6,   �� 5      $
��Test��6   $��Center=�6*   �� 5       $��Tester��6   $��Center=�6,   �� 5!      $��Trainee��6   $��Center=�6-   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ grid_dataSource_test��5$   /   $��Stretch=�6      HeadersVisibility$ Column=�6M   $��1��6h      AutoGenerateColumns .     CanUserAddRows .  ��6u   �� ��5%      �� 5&       �� 
TargetType"  6    �� Triggers 5'      �� 5(      	 �� Binding	 6&   �� 
 �� ElementName$
 testErTrain�� �� Path$ SelectedValue.Content� �� Value Test6n   .a�5)      ��  �� Property � y� �� Value$ Visible=�6;   5*      �� 5+      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Trainee6n   .a�5,      ��  � y�$ Hidden=�6;   5-      �� 5.      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Tester6n   .a�5/      ��  � y�$ Hidden=�6;   50      �� 51      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Select6n   .a�52      ��  � y�$ Hidden=�6;   53      55        57      *  $System.Windows.Controls.DataGridCell  IsEnabledStyle  centerCheckBox��%�  &	       &	 �     �� 58      "  6    59      �� 5:      	 6&   �� *
isFinish+ True6C   .a�5;      ��  � {� . 6:   5<      �� 5=      	 6&   �� *
isFinish+	 False6C   .a�5>      ��  � {� .  6:   5?      5A      �� 5B      " ��6   .�5C      ��  � ��$ Center=�6<   �� 5D       � ��$ Center=�6:   5E      5F         Columns 5G      4  .System.Windows.Controls.DataGridTemplateColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)      Header$
 Edit��66      CellTemplate 5I      �� 5J      .R�5K      �� $��button_edit_test��6%   -   5        $
��Edit��5K   =   6L   5L      5N      4  .System.Windows.Controls.DataGridCheckBoxColumn  5O      $
 auto 6)   $ Test Finished��66   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6�      Binding 6M   �� *
isFinish+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5P      $
 auto 6)   $ Success��66      	CellStyle# [ 6�   # [ 6�    6G   �� *grade+$ PropertyChanged=�6�     5Q      $
 auto 6)   $ Comment��66   # [ 6G    5R      �� 5S      .R�5T      9� $��exp_com_test��6'   $��Center=�6;   $��Center=�6X   .��5U   "   �� .+�5V   &   � $��myPopup_com��6,    � 	StaysOpen .  ��5W   *   �� 5X   .    5Y   2   �� 5Z   6   	 6B   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" 9�$ 
IsExpanded� True6�   .a�5[   :   ��  � �� . 6Y   5\   7   �� 5]   6   	 6B   ��  �� *FindAncestor+" 9�$ 
IsExpanded�	 false6�   .a�5^   :   ��  � �� .  6Y   5_   7   5a   /   .��5c   *   �� 
�������$��73��6D   $	��143��6P   $��3q�6\   
�������._�5d   .   �  5e   2   �� 5f   6   $��* �6D    � ColumnDefinitions 5h   2   �� 5i   6   $��* �6G   .+�5k   2   ��  ��Name$ textBox��6x   $
��Left=�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��70��6�   $	��140��6�   ��6:   �� *	comment+$ PropertyChanged=�6�   5l   /   5m   +   5n   '   5o   #   5p      5q      5s      0	  *System.Windows.Controls.DataGridTextColumn	  5t      $
 auto 6%   $ ID test��62      
IsReadOnly .  6C   �� *	id_test+6_   	  5u      $
 auto 6%   $ 	ID tester��62    .  6E   �� *	ID_tester+6c   	  5v      $
 auto 6%   $ 
ID trainee��62    .  6F   �� *
ID_trainee+6e   	  5w      $
 auto 6%   $ 	Date test��62    .  6E   �� *	Date_test+6c   	  5x      $
 auto 6%   $ Type car��62    .  6D   �� *	typeCar+6`   	  5y      $
 auto 6%   $ Start address��62    .  6I   �� *Address_test_start+6p   5{        5}   
   -   5        $��grid_dataSource_tester��5}   /   $��Stretch=�6   $ Column=�6M   $��1��6h    .     
IsReadOnly . ��6u   �� ��5~      �� 5      "  6    5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Tester6n   .a�5�      ��  � y�$ Visible=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Trainee6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Test6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Select6n   .a�5�      ��  � y�$ Hidden=�6;   5�      5�       5�        5�      $
 auto 6)   $
 Edit��66    5�      �� 5�      .R�5�      �� $��button_edit_tester��6%   -   5        $
��Edit��5�   ?   6N   5�      5�        5�      $
 auto 6)   $ Remove��66    5�      �� 5�      .R�5�      �� $��button_remove_tester��6%   -   5        $��Remove��5�   A   6R   5�      5�        5�      $
 auto 6)   $ Work day��66    5�      �� 5�      .R�5�      �� $��button_show_workday��6%   -   5        .��5�   "   �� .+�5�   &   �� $��Work day��6,   $��-6q�6?   � 5�   &   $��myPopupWorkday��6,    .  .��5�   *     $��dataGrid_WorkDay��63    . 
�������$��1q�5�   K   ��5�   K   �� *
Work_day+ �� 	Converter# [  5�   K   5�   '   5�   #   5�      5�      5�      	  5�      $
 auto 6%   $ ID��62    6>   �� *ID+	  5�      $
 auto 6%   $ 	Last name��62    6E   �� *
LastName+	  5�      $
 auto 6%   $ 
First name��62    6F   �� *	FirstName+	  5�      $
 auto 6%   $ Birthday��62    6D   �� *
BirthDay+  �� StringFormat$  d��	  5�      $
 auto 6%   $ Phone��62    6A   �� *Phone+	  5�      $
 auto 6%   $ Address��62    6C   �� *	address+	  5�      $
 auto 6%   $ 
Experience��62    6F   �� *Xp+	  5�      $
 auto 6%   $ Max test��62    6D   �� *
Max_test+	  5�      $
 auto 6%   $ Type car��62    6D   �� *
Type_car+5�        5�   
   -	   5        $ grid_dataSource_trainee��5�   J   $��Stretch=�6   $ Column=�6/   $��1��6l    .   . ��6y   �� ��5�      �� 5�      "  6    5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Trainee6n   .a�5�      ��  � y�$ Visible=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Test6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Tester6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Select6n   .a�5�      ��  � y�$ Hidden=�6;   5�      5�       5�        5�      $
 auto 6)   $
 Edit��66    5�      �� 5�      .R�5�      �� $��button_edit_trainee��6%   -
   5        $
��Edit��5�   @   6O   5�      5�        5�      $
 auto 6)   $ Remove��66    5�      �� 5�      .R�5�      �� $��button_remove_trainee��6%   -   5        $��Remove��5�   B   6S   5�      5�      	  5�      $
 auto 6%   $ ID��62    6>   �� *ID+	  5�      $
 auto 6%   $
 Name��62    6@   �� *Name+	  5�      $
 auto 6%   $ Gender��62    6B   �� *gender+	  5�      $
 auto 6%   $ Birthday��62    6D   �� *
BirthDay+$  d��	  5�      $
 auto 6%   $ Phone��62    6A   �� *Phone+	  5�      $
 auto 6%   $ Address��62    6C   �� *	address+5�      � 5�   
   -   5        ! �Name$! grid_Select��5�   +   $��Stretch=�6   $��1��6A   ��5�      �� 5�      " �6    5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Trainee6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content� Test6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Tester6n   .a�5�      ��  � y�$ Hidden=�6;   5�      �� 5�      	 6&   �� $
 testErTrain��$ SelectedValue.Content�
 Select6n   .a�5�      ��  � y�$ Visible=�6;   5�      5�       5      �� 5     $��* �6#   �� 5     $��* �6#   .+�5       -   5        $ grid_Select_Grouping��5  N   $��Stretch=�6   $ Column=�63    .   . ��6l   ��  5     	  5     $
 auto 6)   $ ID��66    6B   �� *ID+	  5     $
 auto 6)   $ 	Last name��66    6I   �� *
LastName+	  5     $
 auto 6)   $ 
First name��66    6J   �� *	FirstName+	  5	     $
 auto 6)   $ Address��66    6G   �� *	address+	  5
     $
 auto 6)   $ Type car��66    6H   �� *
Type_car+5     � 5     $��1��6    5     �� 5     $��* �6$   �� 5     $��* �6$   .+�5     �� 
����iA�$��1q�61   ._�5     �� .+�5     �� $��Group by type of car:��6    
����iA�$��Center=�6W   �� 5     $&�� Ordered(if not then descending):��6    
����iA�$
��Left=�6b   $��Center=�6}   �� 5     -   5        $��TypeCar_check��5  #   $��Center=�68   $
��Left=�6S   �� 5     -   5        $��groupTypeCar��5  #   $��Center=�6h   $��Center=�6�   .@�5     �� $	��Car��6+   $��Center=�69   �� 5     $��	Motorbike��6+   $��Center=�6?   �� 5     $��Truck��6+   $��Center=�6;   �� 5     $	��Van��6+   $��Center=�69   5     5     5     �� 5     $��1��6   
����iA�$��1q�6>   ._�5      �� .+�5!     �� $��Group by City:��6    
����iA�$��Center=�6P   �� 5"     $&�� Ordered(if not then descending):��6    
����iA�$
��Left=�6b   $��Center=�6}   �� 5#     -   5        $��	Add_check��5#  #   $��Center=�64   $
��Left=�6O   �� 5$     -   5        $��groupAddress��5$  #   $��Center=�6�   $��Center=�6�   ��67   �� 6�   5%     5&     5'     5(     5)     5*     