   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       WpfApp2.DelNanny   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   +BEclr-namespace:BE;assembly=BE     5   	     � Title$  Delete Nanny��5	   	   $	��300��6   $��331.325��6+   ���	#FFE59191.��5      � ���#e9e5dd$��0,0,-3.667,-0.333q�6    $
��Left=�6;   $	��331��6V    � ColumnDefinitions 5   
   �� 5      .+�5   
   � -   5         �Name$ grid1��5      $
��Left=�6   $��	20,16,0,0q�6:   $	��Top=�6M    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��27.551 �6    �� 5      $��36.449 �6    �� 5      $
��Auto �6    .+�5      �� $��Nanny Address:��6   $��0��6-   $
��Left=�6=   $��3,0,0,1.551q�6X   $��3��6m   $��Center=�6z   �� 5      -   5         ��Name$ nannyAddressTextBox��5      $
��Left=�63   $��24��6N   $��2.667,7,0,33q�6Z   $��3��6p   $��Center=�6�   $	��120��6�   {�.  $��2��6  $��1��6,  ��6}   �� *NannyAddress+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6,  �� 5      $��Nanny Birth:��6   $��0��6+   $
��Left=�6;   $��3,3,0,3q�6V   $��1��6g   $��Center=�6t   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ nannyBirthDatePicker��5      $��1��67   $
��Left=�6G   $��2.667,4,0,4q�6b   $��1��6w   $��Center=�6�   {�.  	   SelectedDate	 6�   �� *
NannyBirth+$ TwoWay=� .  . 6
  �� 5       $��Nanny First Name:��6   $��0��60   $
��Left=�6@   $��3,3,0,3q�6[   $��2��6l   $��Center=�6y   �� 5!      -   5        $ nannyFirstNameTextBox��5!      $��1��65   $
��Left=�6E   $��24��6`   $��2.667,4,0,4q�6l   $��2��6�   $��Center=�6�   $	��120��6  {�.  ��6�   �� *NannyFirstName+$ TwoWay=� .  . 6  �� 5"      $��	Nanny Id:��6   $��0��6(   $
��Left=�68   $��18,4,0,2q�6S   $��Center=�6e   �� 5#      -   5        $ nannyIdTextBox��5#      $��1��6.   $��24��6>   $��2.667,6,0,2q�6J   $��Center=�6�   ��6_   �� *	NannyId+$ TwoWay=� .  . 6�   �� 5$      $��Nanny Last Name:��6   $��0��6/   $
��Left=�6?   $��3,7.449,0,3q�6Z   $��4��6o   $��Center=�6|   �� 5%      -   5        $ nannyLastNameTextBox��5%      $��1��64   $
��Left=�6D   $��24��6_   $��2.667,8.449,0,4q�6k   $��4��6�   $��Center=�6�   $	��120��6  {�.  ��6�   �� *NannyLastName+$ TwoWay=� .  . 6  �� 5&      $��Nanny Phone:��6   $��0��6+   $
��Left=�6;   $��3,3,0,3q�6V   $��5��6g   $��Center=�6t   �� 5'      -   5        $ nannyPhoneTextBox��5'      $��1��61   $
��Left=�6A   $��24��6\   $��2.667,4,0,4q�6h   $��5��6}   $��Center=�6�   $	��120��6  {�.  ��6�   �� *
NannyPhone+$ TwoWay=� .  . 6  5(      �� 5)   
   -   5        $�� ��5)      $
��Left=�6   $��
253,23,0,0q�67   $	��Top=�6K   $��30��6c   $��24��6n   ��5*      �� 5+      
 �� ImageSource$
 image/th (1).jpg��6   5-      �� 5.   
   -	   5        ���#D586A2$��Delete��5.   (   $
��Left=�69   $��
66,213,0,0q�6T   $	��Top=�6h   $	��187��6�   $��32��6�   6�   5/      50      