   M S B A M L   `   `   `  ����  MachineNewGUI&     MachineNewGUI.ErrorMessageWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Robot Error Message��5   	   $	��600��6%   $	��700��62    � WindowStartupLocation$ CenterScreen=�6>    � 
ResizeMode$ NoResize=�6c   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 0,1&�6/   .��5      �  � Offset$ 0Q�6    � Color$ DarkBlue��6&   69   � 5      $	 0.7Q�6   $ 
PowderBlue��6(   6=   � 5	      $ 1Q�6   $ 	PaleGreen��6&   6:   5
       � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $:	 4/MachineNewGUI;component/Resources/ScrollViewer.xaml?�6%   %    5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��1.5* �6   6,   �� 5      $��2* �6   6*   �� 5      $��5* �6   6*   �� 5      $
��1.5* �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6$   $��26(�61   $	��150��6?   $��40��6K   
�������Error Code:6|   �� 5    
   -   5        $��textblockErrorCode��5       $��1��6.   $��0��6>   $��26(�6K   $	��150��6Y   $��40��6e   
�������
CodeHere6�   �� 5!   
   -   5        $��textboxErrorMessage��5!      $��0��6-   $��1��6=   $��3��6J   $��26(�6^   $��5q�6l   $��40��6w   $��80��6�   
���  �� �� TextWrapping$
 Wrap=�6�    �� 
IsReadOnly . .��6�   PleaseClearIndexerPlacePos6�   �� 5"   
   -   5        $��textboxErrorDescription��5"      $��0��61   $��2��6A   $��3��6N   $��20(�6b   $��5q�6p   
���   �$
 Wrap=�6�    . 6�   A� 5#   
   $��0��6   $��3��6&   $��3��6:    A� Rows$ 1��6G   .+�5$      �� -   5        $��buttonRetry��5$      $��0��6(      greenbutton#��[  68   .��6w   RETRY6~   �� 5%      -   5        $��
buttonSkip��5%      $��1��6'     	redbutton#��[ 67   .��6�   SKIP6�   �� 5&      -   5        $��buttonManualLoad��5&      $��2��6-     bluebutton_ExtendWidth#��[ 6=   $	��110��6�   $y�	Collapsed=�6�   .��6�   Manual Load6�   �� 5'      -   5        $��buttonBuzzerOff��5'      $��3��6,     yellowbutton#��[ 6<   .��6�   
Buzzer Off6�   5(      5)      5*      