   M S B A M L   `   `   `  ����  MachineNewGUI.    (MachineNewGUI.Service.MachineStateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MachineStateWindow��5   	   $��38��6$   $	��300��60    � Left$
 1000��6<   
 � Top$ 1��6H    � WindowState$ Normal=�5   	    � WindowStyle$
 None=�6    � AllowsTransparency . 
��� ��� � Topmost . |�.   � ShowInTaskbar .   � 	Resources 5      	 �� 
TargetType
 �� Triggers :� RoutedEvent g� AutoReverse g� RepeatBehavior �� TargetProperty	 W� To��%�   '��       �� 5   
   "	 ��6   
 5      :� 5	      $ Loaded��6   [�5
      �� 5      .��5      ��  . $ Forever��6<   .��5   "   W� $ Opacity�62   $ 0X�6V   6_   5      5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��textBlockDoorOpen��5      $��Center=�6-   $��Center=�6H   $��24(�6e   
���  ��$��5q�6�   	Door Open6�   �� 5   
   -   5        $��textBlockPause��5      $��1��6*   $��Center=�6:   $��Center=�6U   $��24(�6r   
���  ��$��5q�6�   Pause6�   5      5      