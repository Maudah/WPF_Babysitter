   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       WpfApp2.Child   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$  Add/update child details��5	   	   $��406.827��6*   $��377.109��6;   .��5      � ���#e9e5dd$��0,0,-4,-3.667q�6!   .+�5   
   � -   5         �Name$ grid1��5      $
��Left=�6   $��	28,24,0,0q�6:   $	��Top=�6M   $	��215��6e   $	��276��6r    � ColumnDefinitions 5      �� 5      $
��Auto �6#   $	��130��60   �� 5      $
��Auto �6#   $	��139��60    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Date of birth��6   $��0��6,   $
��Left=�6<   $��3,4,0,4q�6W   $��3��6h   $��Center=�6u   $��26��6�   $��45��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ childBirthDatePicker��5      $��1��67   $
��Left=�6G   $��3,4,0,6q�6b   $��3��6s   $��Center=�6�   $��24��6  $	��128��6     SelectedDate 6�   �� *
ChildBirth+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6  �� 5      $��
First name��6   $��0��6)   $
��Left=�69   $��3,3,0,4q�6T   $��1��6e   $��Center=�6r   $��26��6�   $��57��6�   �� 5      -   5        	 ��Name$	 childFistNameTextBox��5      $��1��64   $
��Left=�6D   $��23��6_   $��3,5,0,5q�6k   $��1��6|   $��Center=�6�   $	��120��6
  ��6�   �� *ChildFistName+$ TwoWay=� .  . 6
  �� 5      $��ID��6   $��0��6!   $
��Left=�61   $��3,4,0,3q�6L   $��0��6]   $��Center=�6j   $��96��6�   $��26��6�   �� 5      -   5        $	 childIdTextBox��5      $��1��6.   $
��Left=�6>   $��23��6Y   $��3,5,0,5q�6e   $��0��6v   $��Center=�6�   $	��120��6�   ��6�   �� *	ChildId+$ TwoWay=� .  . 6=  �� 5      $��	Mother ID��6   $��0��6(   $
��Left=�68   $��3,3,0,4q�6S   $��2��6d   $��Center=�6q   $��26��6�   $��52��6�   �� 5       -   5        
 ��Name$
 momIdComboBox��5       $��1��6.   $
��Left=�6�   $��22��6�   $��3,5,0,6q�6  $��2��6  $��Center=�6  $	��120��6:   �� Text 6r   �� *GetMotherList+$ TwoWay=� .  . 5"      �� 5#      $��Special needs?��6   $��0��6-   $
��Left=�6=   $��3,4,0,3q�6X   $��4��6i   $��Center=�6v   $��26��6�   $��90��6�   �� 5$      -   5         ��Name$ specialBoyCheckBox��5$      $�� ��63   $��1��6>   $
��Left=�6N   $��3,9,0,9q�6�   $��4��6�   $��Center=�6�   $��15��6
  $��20��6   d� 	IsChecked 6i   �� *
SpecialBoy+$ TwoWay=� .  . 6  �� 5%      $��other details��6   $��0��6,   $
��Left=�6<   $��3,3,0,4q�6W   $��5��6h   $��Center=�6u   $��26��6�   $��83��6�   �� 5&      -   5        $	 specialBoyDetailsTextBox��5&      $��1��68   $
��Left=�6H   $��23��6c   $��3,5,0,5q�6o   $��5��6�   $��Center=�6�   $	��120��6  ��6�   �� *SpecialBoyDetails+$ TwoWay=� .  . 6  5'      �� 5(   
   -   5        $�� ��5(      $
��Left=�6   $��19��67   $��
288,33,0,0q�6C   $	��Top=�6W   $��24��6o   ��5)      �� 5*       �� ImageSource$ image/th (1).jpg��6   5,      �� 5-   
   -	   5        ���#D586A2$��Add or update��5-   &   $
��Left=�6>   $��117,244,0,0q�6Y   $	��Top=�6n   $	��169��6�   $��50��6�   6�   5.      5/      