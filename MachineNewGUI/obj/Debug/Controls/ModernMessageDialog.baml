   M S B A M L   `   `   `  ����H  DMachineNewGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MachineNewGUI.ControlsMachineNewGUI.Controls  5      0    *MachineNewGUI.Controls.ModernMessageDialog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6local$clr-namespace:MachineNewGUI.Controls     5      -   5        $	��200��5      $	��400��6   
�������.��5      ��   �� CornerRadius$  15��6   ���#DDDDDD$��1q�65    �� Padding$ 20q�6I   ��6V   �� *BackgroundColor+._�5   
   �  � RowDefinitions 5	      �� 5
      $��* �6    �� 5      $
��Auto �6    .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6M   .+�5      �� -   5         ��Name$ 	TitleText��5      $��20(�6/   $
��Bold"�6=   
������� �� TextAlignment$ Center=�6b   $��0,0,0,10q�6y   �� 5      -   5        $ MessageText��5      $��16(�61   
�������$ Center=�6R   $
��Wrap=�6i   5      �� 5      $��1��6   $ 
Horizontal=�6&   $��Center=�6?   $��0,20,0,0q�6\   .+�5      �� -   5         ��Name$ OkPanel��5      $ 
Horizontal=�6.   $y�	Collapsed=�6G   .+�5      �� -   5        $��OK��5      $��80��6*   $��5q�65   6@   5      �� 5      -   5        $ 
YesNoPanel��5      $ 
Horizontal=�61   $y�	Collapsed=�6J   .+�5      �� -   5        $	��Yes��5      $��80��6+   $��5q�66   6A   �� 5      -   5        $��No��5      $��80��6*   $��5q�65   6@   5      5      5      5      5      