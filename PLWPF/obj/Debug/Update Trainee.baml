   M S B A M L   `   `   `  ����=  9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   @ <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF 5   	      PLWPF.Update_Trainee   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -myBEclr-namespace:BE;assembly=BE     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   -   5        $��myWin��5	        � Title$  Update��5
   	   $	��300��6C   $	��300��6g   $��1q�6v   
���   �
������� � 	Resources 5       S� 
MethodName S� 
ObjectType  System.Enum   GetEnumGender S� MethodParameters M� TypeName �� 
TargetType " StyleListSelectedValidComboBox �� Property �� Value	 �� ElementName
 �� Path(  "System.Windows.Controls.DatePicker  StyleDatimeValidDatePicker  mystyleTextbox  StyleLengthValidTextBox �� BasedOn  mystyleLabel  stylHeaderdatagrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader  mystyledatagrid&   System.Windows.Controls.DataGrid��%  &	        &	 h     &	 �    &	 |    &	     7  &	 �    &	 a    &	 �    7  S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ myBE:Gender��6   5      �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� $	��Top=�6(   
���  ��$
��12pt(�6N   ��5   !   �� $	 	MyAdorner��$8
 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      
���  ��$��1q�67   ._�5   "   �� $��	MyAdorner��6<   5      5      5      5       5!      �� 5"   
   "  6   .�5#      ��  �@=�ErrorTemplate 5$      �� 5%      .R�5&      ]� ��. .+�5'      �� $	��Top=�6(   
���  ��$
��12pt(�6N   ��5(   !   �� $	 	MyAdorner��$8
 2AdornedElement.(Validation.Errors)[0].ErrorContent�5*      �� 5+      
���  ��$��1q�67   ._�5,   "   �� $��	MyAdorner��6<   5-      5.      5/      51      52      �� 53   
   " ��6'   .�54      ��  � ��$ Center=�62   �� 55       � ��$ Stretch=�64   �� 56       � ��$ 1q�6'   57      �� 58   
   " ��6   8   .�59      ��  �@=�ErrorTemplate 5:      �� 5;      .R�5<      ]� ��. .+�5=      �� $	��Top=�6(   
���  ��$
��12pt(�6N   ��5>   !   �� $	 	MyAdorner��$8
 2AdornedElement.(Validation.Errors)[0].ErrorContent�5@      �� 5A      
���  ��$��1q�67   ._�5B   "   �� $��	MyAdorner��6<   5C      5D      5E      5G      5H      �� 5J   
   " ��6%   .�5K      ��  � ��
 �����6+   �� 5L       � ��$ Center=�62   �� 5M       � ��$ Stretch=�64   �� 5N       � ��$ 1q�6'   5O      �� 5P   
   "  6+   .�5Q      ��  � ��
 �����6+   �� 5R       � ��$ Italic$�6*   �� 5S       � ��$
 Bold"�6+   5T      �� 5U   
   "  6(   .�5V      ��  � ��$ 1q�60   �� 5W       �@ ColumnHeaderStyle8   62   �� 5X       � ��
 �����6,   �� 5Y       � ��$ 3q�60   5Z      5[      .��5\      � -   5        $��UpdateTrainee��5\      
�������$��3q�63    � RowDefinitions 5]   
   �� 5^      $	��30* �6   �� 5_      $
��200* �6   �� 5`      $	��30* �6   .+�5b   
   � $��1��6    5c      �� 5d      $��* �6    �� 5e      $��* �6    �� 5f      $��* �6     � ColumnDefinitions 5h      �� 5i      $��* �6#   $��95��6-   �� 5j      $��* �6#   $��95��6-   �� 5k      $��* �6#   $��95��6-   �� 5l      $��* �6#   $��95��6-   .+�5n      �� -   5        $��label_trainee_ID��5n      $	��ID:��6,   $��1q�6:   #��[ 6E   �� 5o      -   5        $��label_trainee_Name��5o      $��Name:��6.   $��1��6>   #��[ 6K   �� 5p      -   5        $��label_trainee_birthday��5p      $��	Birthday:��62   $��2��6F   #��[ 6S   �� 5q      -   5        $��label_trainee_phone��5q      $��Phone:��6/   $��2��6@   #��[ 6P   �� 5r      -   5        $��label_trainee_Adrress��5r      $��Adrress:��61   $��2��6D   $��1��6T   #��[ 6a   �� 5s      -   5        $��label_trainee_Gender��5s      $��Gender:��60   $��2��6B   $��2��6R   #��[ 6_   �� 5u      -	   5        $��text_trainee_ID��5u      {�.  $��1��6X   #��[ 6h   ��6-   �� $
 ID�.��6�   .��5{      5|      �� 5}      -
   5        $��text_trainee_Name��5}      $��1��6/   $��1��6?   #��[ 6L   .��6}   .��5~      �� $
 .Name�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5      %  PLWPF.StringRangeValidationRule  5�         MinimumLength$ 1��5�         MaximumLength$ 20��6/   5�      5�        5�      -   5        $!��datepicker_trainee_birthday��5�   @   $��Center=�6c   $��Center=�6�   $��1��6�   $��2��6�   $��1q�6�   #��[ 6�      SelectedDate 6   �� $
 BirthDay�6�   �� 5�      -   5        $��text_trainee_phone��5�      $��3��60   #��[ 6@   .��6q   .��5�      �� $
 .Phone�6   $ PropertyChanged=�6(    5�        PLWPF.RegexValidationRule  5�         	RegexText$8 2^\+?(972|0)(\-)?0?(([23489]{1}\d{7})|[5]{1}\d{8})$��5�         ErrorMessage$ Invalid phone number��5�         RegexOptions$ 
IgnoreCase=�5�      5�      5�      �� 5�      -   5        $��combo_trainee_Gender��5�      $��Stretch=�64   $��Center=�6R   $��3��6m   $��2��6}   $��1q�6�   #��[ 6�    �� SelectedValue 5�      �� 5�      $
 .gender�6   $ PropertyChanged=�6-    5�      (  "PLWPF.ListIsSelectedValidationRule  5�         ErrorMessage$ A Selection is required��5�   !   5�      5�      �� 5�      -   5        $��button_trainee_Adrress��5�      $��Stretch=�63   $��Center=�6Q   $��3��6l   $��1��6|   $��	3,23,3,23q�6�   .��5�      �� .+�5�      �� $��address��6   � 5�      -   5        $��myPopup��5�       � 	StaysOpen .  .��5�      �� 
�������$	��100��64   $	��150��6A   $��3q�6M   
�������._�5�      �  5�   "   �� 5�   &   $��* �64   �� 5�   &   $��* �64   �� 5�   &   $��* �64    5�   "   �� 5�   &   $
��auto �67   �� 5�   &   $��* �67   .+�5�   "   �� $��City:��6(   #��[ 68   �� 5�   "   -   5        $��	text_City��5�   U   $��1��6*   #��[ 6f   ��6:   �� $

 City�6f   �� 5�   "   $��1��6(   $
��Num:��65   #��[ 6D   �� 5�   "   -   5        $��text_Num��5�   *   $��1��6T   $��1��6d   #��[ 6q   ��6:   �� $	
 Num�6q   �� 5�   "   $��2��6(   $��Street:��65   #��[ 6G   �� 5�   "   -   5        $��text_Street��5�   W   $��1��6*   $��2��6j   #��[ 6w   ��6:   �� $
 Street�6w   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $��title_trainee��5�      $��Update Trainee��6%   $��Center=�6>   $��Center=�6b   
�������6�   �� 5�   
   -   5        $��button_trainee_update��5�      $��2��6.   $��Update the trainee��6;   $��Center=�6|   $��Center=�6�   5�      5�      