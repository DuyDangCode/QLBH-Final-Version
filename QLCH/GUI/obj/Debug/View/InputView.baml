   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GUI.ViewGUI.View  5          GUI.View.InputView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:GUI.View     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  63   
������ .��5      ��   �� CornerRadius$  12��6   ._�5   
   �� $  15��6   $��2q�5       J� Opacity$
 0.95Q�5      
���������5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5      $ #DA34AE��6#   $
 0.75Q�63   � 5      $ #8A16C1��6#   $ 1Q�63   5      ._�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      6&   .+�5      #  MaterialDesignThemes.Wpf.Card  $��0��6&   $��5q�63   .��5       �  � ColumnDefinitions 5!      �� 5"      61   �� 5#      61   �� 5$      61   �� 5%      61   �� 5&      61   .+�5(      � $��0��6   .+�5)      ��  �� DisplayMemberPath$
 name��6'   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Sản phẩm��6�   
 �� 
IsEditable
 .  &  "MaterialDesignFloatingHintComboBox#��[  6�   ��6@   �� *ListProduct+ �� SelectedItem 6d   �� *SelectedProduct+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�69  5*      � 5+      $��1��6   .+�5,      ��  �� 
IsReadOnly . $
 name��69   $	 
Danh mục��6�   
 . #��[  6  ��6R   �� *ListCategory+ 6w   �� *SelectedCategory+$ TwoWay=�$ PropertyChanged=�6M  5-      � 5.      $��2��6   .+�5/      �� $��5q�6b   $	 Số lượng��6m    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6&   �� *count+$ PropertyChanged=�6�   50      � 51      $��3��6   .+�52      �� $��5q�6g   $	 	Giá bán��6r   #��[ 6�   ��6&   �� *
totalprice+$ PropertyChanged=�6�   53      � 54      $��4��6   .+�55      (  "System.Windows.Controls.DatePicker  $��Center=�6)   $	��100��6�   $��
5 5 15 3.9q�6�   $	 Ngày nhập��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6D   �� *
Date_Input+$ TwoWay=�$ PropertyChanged=�6�   56      57      58        5:      $��1��6&   $��5q�63   .��5;      � .+�5<      �� $��Nhập hàng��6B   $��5q�6V   $	��150��6a   ��6!   �� *InputCommand+6o   5=      5>        5@      $��2��6&   $��5q�63   $��Stretch=�6>   .��5A      ��   MaterialDesignListView#��[ 6   ��6O   �� *	ListInput+ 6q   �� *SelectedInput+$ OneWayToSource=� �� View 5B      �� 5C      .P�5D   "   ��  " MaterialDesignFlatAccentButton �� HeaderContainerStyle# [ 61   $��Sản phẩm��6y    �� DisplayMemberBinding 6�   �� *productname+6�   �� 5E   "   # [ 61   $��Doanh mục��6y    6�   �� *
idCategory+6�   �� 5F   "   # [ 61    �� Width$	 200��6y   $��Ngày nhập��6�    6�   �� *date+6�   �� 5G   "   # [ 61   $	 150��6y   $��Số lượng��6�    6�   �� *sl+6�   �� 5H   "   # [ 61   $	 150��6y   $��	Giá bán��6�    6�   �� *
totalprice+6�   5I      5K      5L      5M      5N      5O      5P      