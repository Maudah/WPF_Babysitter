   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5   	       WpfApp2.DelContract   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	   +BEclr-namespace:BE;assembly=BE     5   	   -   5          � Title$  Delete a contract��5	   	   $	��300��6#   $��401.205��60   .��5      � ���#e9e5dd.+�5   
   � -   5         �Name$ grid1��5      $	��Top=�6   $��	21,23,0,0q�66   $
��Left=�6I    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��Center=�6   $��0��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Child ID��6r   �� 5      -   5         ��Name$ childIDTextBox��5      $	��120��6.   $��Center=�6:   $��0��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6U   �� *	ChildID+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6-  �� 5      $��Center=�6   $��3��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��End date��6r   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ endingDateDatePicker��5      $��Center=�67   $��3��6�   $��3q�6�   $
��Left=�6�   $��1��6�   	   SelectedDate	 6R   �� *
EndingDate+$ TwoWay=� .  . 6�   �� 5      $��Center=�6   $��2��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��	Mother ID��6r   �� 5      -   5        $ momIdTextBox��5      $	��120��6,   $��Center=�68   $��2��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6S   �� *MomId+$ TwoWay=� .  . 6�   �� 5      $��Center=�6   $��1��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��Nanny ID��6r   �� 5       -   5        $ nannyIDTextBox��5       $	��120��6.   $��Center=�6:   $��1��6�   $��3q�6�   $��23��6�   $
��Left=�6�   $��1��6�   ��6U   �� *	NannyID+$ TwoWay=� .  . 6�   �� 5!      $��Center=�6   $��4��6/   $��3q�6<   $
��Left=�6G   $��0��6b   $��
Start date��6r     5"      -   5        $ startingDateDatePicker��5"      $��Center=�69   $��4��6�   $��3q�6�   $
��Left=�6�   $��1��6�   	 6T   �� *StartingDate+$ TwoWay=� .  . 6�   5#      �� 5$   
   -   5        $�� ��5$      $
��Left=�6   $��
226,40,0,0q�67   $	��Top=�6K   $��20��6c   $��23��6�   
 J� RenderTransformOrigin$
 0.343,0.597&�6�   ��5%      �� 5&       �� ImageSource$ image/th (1).jpg��6   5(      �� 5)   
   -	   5        $ codeforsearch��5)      $
��Left=�6)   $��23��6D   $��
251,40,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5*   
   $��Insert contract code��6   $
��Left=�6/   $��
273,18,0,0q�6J   $	��Top=�6^   $��98��6v   �� 5+   
   -
   5        $��Delete��5+      ���#D586A2$
��Left=�69   $��133,203,0,0q�6T   $	��Top=�6i   $	��215��6�   $��35��6�   6�   5-      5.      