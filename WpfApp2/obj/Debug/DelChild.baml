   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       WpfApp2.DelChild   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          � Title$  Delete child��5	   	   $��286.345��6   $��339.357��6/   .��5      � $��0,0,-3.667,-1.667q�6   ���#e9e5dd.+�5   
   � -   5         �Name$ grid1��5      $	��Top=�6   $��	36,36,0,0q�66   $
��Left=�6I   $	��116��6e   $	��270��6r    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
First name��6r   �� 5      -   5         ��Name$ childFistNameTextBox��5      $	��120��64   $��Center=�6@   $��1��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6   {�.  ��6[   �� *ChildFistName+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6  �� 5      $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Child ID��6r   �� 5      -   5        $ childIdTextBox��5      $	��120��6.   $��Center=�6:   $��0��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6U   �� *	ChildId+$ TwoWay=� .  . 6�   �� 5      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��	Mother ID��6r   �� 5      -   5        $ momIdTextBox��5      $	��120��6,   $��Center=�68   $��2��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   {�.  ��6S   �� *MomId+$ TwoWay=� .  . 6   �� 5      -   5        $�� ��5      $��1��6    $
��Left=�60   $��128.333,6,-23.333,0q�6K   $	��Top=�6h   $��28��6�   $��24��6�   ��5      �� 5       �� ImageSource$ image/th (1).jpg��6!   5!      5"      �� 5#   
   -   5        ���#D586A2$��Delete��5#   (   $
��Left=�69   $��109,173,0,0q�6T   $	��Top=�6i   $	��140��6�   $��40��6�   6�   5%      5&      