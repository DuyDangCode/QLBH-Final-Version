   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	   'clr-namespace:GUI.ViewMD
GUI.ViewMD  6r       GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	   X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  6)   (	viewModelclr-namespace:GUI.ViewMD  6r   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��
mainWindow��5   	     � Title$  MainWindowView��5	   	   $	��600��6    $
��1100��6-    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency .  
  MainVM � DataContext# [  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedWindowCommand+	   CommandParameter	 5   $   �� 
 �� ElementName$
 
mainWindow��5      .��5      ��  �� CornerRadius$ 10��6   $��1q�5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      $��* �6#   .+�5!      �� $ 	10,0,0,10��6   $��0��5"      ��5$      �� 5%      .��5&      �   primaryBackColor1 � Color# [ 6'   5'      ._�5)      �� .+�5*      ��  �� Orientation$ 
Horizontal=�6!   $��35��5+      $��
15,25,0,40q�5,      .+�5-      �� $��/Img/online-shopping.png��6    $��35��5.      �� 5/      $��Grocery Store��6$   
�������$��25(�51       $��Medium"�52       $��
Montserrat)�53       $��Center=�54       $��10,0,0,0q�55       56      	� 58        
menuButton#��[ 6"    
 color1
 � Tag# [ 59   "   ��5:   "   �� *ShowHomeViewCommand+.��5;      �� $ 
Horizontal=�6%   .+�5<      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+     menuButtonIcon#��[ 67   �� 5=      $��Trang chủ��6(     menuButtonText#��[ 69   5>      5?      	� 5A      #��[ 6"    
 color2# [ 5B   "   ��5C   "   �� *ShowInputViewCommand+.��5D      �� $ 
Horizontal=�6%   .+�5E        $ Truck=�6+   #��[ 68   �� 5F      $��QL Kho��6(   #��[ 66   5G      5H      	� 5J      #��[ 6"    
 color3# [ 5K   "   ��5L   "   �� *ShowOrderViewCommand+.��5M      �� $ 
Horizontal=�6%   .+�5N        $ CartPlus=�6+   #��[ 6;   �� 5O      $��Đặt hàng��6(   #��[ 68   5P      5Q      	� 5S      #��[ 6"    
 color4# [ 5T   "   ��5U   "   �� *ShowProductsViewCommand+.��5V      �� $ 
Horizontal=�6%   .+�5W        $ Burger=�6+   #��[ 69   �� 5X      $��Sản phẩm��6(   #��[ 68   5Y      5Z      	� 5\      #��[ 6"    
	 color5# [	 5]   "   ��5^   "   �� *ShowAccountViewCommand+.��5_      �� $ 
Horizontal=�6%   .+�5`        $
 User=�6+   #��[ 67   �� 5a      $��Tài khoản��6(   #��[ 69   5b      5c      	� 5e      #��[ 6"    

 color6# [
 5f   "   ��5g   "   �� *ShowRevenueViewCommand+.��5h      �� $ 
Horizontal=�6%   .+�5i        $ ChartColumn=�6+   #��[ 6>   �� 5j      $��	Doanh thu��6(   #��[ 69   5k      5l      �� 5m      -   5         ��Name$ txtTime��5m       $��	0,135,0,0q�61   $
��Time��6D   
�������$��Center=�6c   $��16(�6�   5n      5o      �� 5p      $ 	0,10,10,0��6   $��1��5q      ��5s      �� 5t      .��5u      �   primaryBackColor2# [ 6'   5v      ._�5y      �  � RowDefinitions 5z      �� 5{      $��25 �6(   �� 5|      $��35 �6(   �� 5}      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   .��5�        $ Xmark=�6+     controlButtonIcon#��[ 68   5�      �� 5�      -   5        $ btnMinimize��5�   !   #��[ 5�   !   # [
 5�   !   .��5�        $ WindowMinimize=�6+   #��[ 6A   5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $��0��6%   $ 
Horizontal=�5�   %   $��Center=�5�   %   .+�5�        $��20��5�   +   $��20��5�   +     titleColor2   
Foreground# [ 5�   +   $��	35,0,10,0q�5�   +    5�   +   �� *Icon+5�   +   �� 5�      #��[ 5�   (   $��16(�5�   (   $��
Montserrat)�5�   (   $��Medium"�5�   (   $��Center=�5�   (   ��5�   (   �� *	Caption+5�   (   5�      �� 5�      $�� 1��6%   $ 
Horizontal=�5�   %   $��RightToLeft=�5�   %   $��Center=�5�   %   $��0,0,10,0q�5�   %   .+�5�      ��   
iconButton#��[ 6%   # [ 5�   %   ��5�   I   �� *LoadedWindowCommand+��6q   �� $
 
mainWindow��.��5�   "     $ PowerOff=�6/     iconButtonIcon#��[ 6?   5�      �� 5�      -   5        $ txtName��5�   (     titleColor3#��[ 5�   (   $��
Montserrat)�5�   (   $��16(�5�   (   $��Center=�5�   (   ��5�   9   �� *DisplayedName+5�   (   d� 5�      $��10,0,0,0q�5�   !    $  MaterialDesignActionToggleButton#��[ 5�   !    � ToolTip$&  MaterialDesignActionToggleButton��5�   !   .��5�   "   �� -   5         ��Name$ 	imgAvatar��5�   (   $��/Img/user.png��5�   %   6>   5�      5�      5�      �� 5�      $��2��5�   %   $��15q�5�   %   ��5�   %   �� *CurrentChildView+5�   %   5�      5�      5�      5�      5�      