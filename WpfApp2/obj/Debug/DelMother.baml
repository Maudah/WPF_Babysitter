   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       WpfApp2.DelMother   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          � Title$  Delete mother��5	   	   $	��300��6   $��351.807��6,   .��5      � ���#e9e5dd � ColumnDefinitions 5   
   �� 5      .+�5   
   � -   5         �Name$ grid1��5      $
��Left=�6   $��	43,26,0,0q�69   $	��Top=�6L   $	��150��6d   $	��228��6q    5      �� 5      $
��Auto �6#   $��82��60   �� 5      $	��133 �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��
First Name��6   $��0��6)   $
��Left=�69   $��3,0,0,3q�6T   $��1��6e   $��Bottom=�6r   $��26��6�   $��57��6�   �� 5      -   5         ��Name$ momFirstNameTextBox��5      $��1��63   $
��Left=�6C   $��22��6^   $��3,4,0,10q�6j   $��1��6|   $��Center=�6�   $	��120��6	  {�.  ��6�   �� *MomFirstName+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6  �� 5      $��ID��6   $��0��6!   $
��Left=�61   $��3,9,0,3q�6L   $��0��6]   $��Center=�6j   $��26��6�   $��71��6�   �� 5      -   5        $ momIdTextBox��5      $��1��6,   $
��Left=�6<   $��22��6W   $��3,11,0,5q�6c   $��0��6u   $��Center=�6�   $	��120��6�   ��6�   �� *MomId+$ TwoWay=� .  . 6�   �� 5      $��	Last Name��6   $��0��6(   $
��Left=�68   $��3,3,0,9q�6S   $��2��6d   $��Center=�6q   $��26��6�   $��72��6�   �� 5      -   5        $ momLastNameTextBox��5      $��1��62   $
��Left=�6B   $��22��6]   $��3,5,0,11q�6i   $��2��6{   $��Center=�6�   $	��120��6  {�.  ��6�   �� *MomLastName+$ TwoWay=� .  . 6  �� 5       $��Phone��6   $��0��6$   $
��Left=�64   $��3,9,0,3q�6O   $��3��6`   $��Center=�6m   $��26��6�   $��68��6�   �� 5!      -   5        $ momPhoneTextBox��5!      $��1��6/   $
��Left=�6?   $��22��6Z   $��3,11,0,5q�6f   $��3��6x   $��Center=�6�   $	��120��6  {�.  ��6�   �� *
MomPhone+$ TwoWay=� .  . 6  5"      �� 5#   
   -   5        $�� ��5#      $
��Left=�6   $��
252,37,0,0q�67   $	��Top=�6K   $��31��6c   $��22��6n    J� RenderTransformOrigin$ 0.24,-0.231&�6z   ��5$      �� 5%      	 �� ImageSource$	 image/th (1).jpg��6   5'      �� 5(   
   -   5        $��Delete��5(      ���#D586A2$
��Left=�69   $��
73,193,0,0q�6T   $	��Top=�6h   $	��157��6�   6�   5)      5*      