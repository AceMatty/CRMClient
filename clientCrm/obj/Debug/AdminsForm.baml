   M S B A M L   `   `   `  ����D  @clientCrm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:clientCrm	clientCrm  5   	       clientCrm.AdminsForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:clientCrm     5   	   -   5          � Title$  Главная��5   	   $	��900��6   $
��1200��6&   ���	#FF402E61 � WindowState$ 	Maximized=�6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��89* �6   �� 5      $
��780* �6   .+�5   
   �� $/��)Панель администратора��6   $��10q�60   $��40(�6<   $��Segoe UI Light)�6J   ���	#26E87ED9���	#FFD8D8E46}   �� 5   
   $��Основные окна��6   $
��Left=�6*   $	��450��6E   $��	10,14,0,0q�6R   $	��Top=�6e   $	��287��6}   ���	#FFE8E2E2$��25(�6�   $��Segoe UI Light)�6�   $��1��6�   ���	#FF7E7A7A.��5      � $
��Left=�6   $	��401��6.   $��4,7,0,0q�6;   $	��Top=�6L   $	��264��6d   .+�5      �� -   5         ��Name$ btnOpenJurn��5      $#��Журнал действий��6.   $��
10,128,0,0q�6H   ���	#FFE87ED9���	#FFE0E0E4$��Segoe UI Light)�6�   $��20(�6�   ���	#FF68686A4  .System.Windows.Automation.AutomationProperties   HelpText$  Вход в систему��6�   $
��Left=�6�   $	��242��6  $��37��6"  $	��Top=�6.  6F  �� 5      -   5        $ btnOpenUsers��5      $-��'Список пользователей��6/   $��	10,67,0,0q�6N   ���	#FFE87ED9���	#FFE0E0E4$��Segoe UI Light)�6�   $��20(�6�   ���	#FF68686A$  Вход в систему��6�   $
��Left=�6   $	��242��6  $��37��6'  $	��Top=�63   �� 	ClickMode$ Press=�6K   J� OpacityMask �	#FF7A6F6F6u  �� 5      -   5        $ btnOpenTasks��5      $��Список задач��6/   $��
10,185,0,0q�6F   ���	#FFE87ED9���	#FFE0E0E4$��Segoe UI Light)�6�   $��20(�6�   ���	#FF68686A$  Вход в систему��6�   $
��Left=�6�   $	��242��6  $��37��6   $	��Top=�6,  6D  �� 5      -   5        $ btnOpenMain��5      $��Главная��6.   $��	12,10,0,0q�6@   ���	#FFE87ED9���	#FFE0E0E4$��Segoe UI Light)�6�   $��20(�6�   ���	#FF68686A$  Вход в систему��6�   $
��Left=�6�   $	��242��6  $��37��6  $	��Top=�6%  $ Press=�6=   �	#FF7A6F6F6g  5      5      �� 5   
   -   5         ��Name$ 
lbUserInfo��5      $0��*Вы вошли как:авав вавав��6$   $��
0,10,10,34q�6F   ���	#FFDADAE4���	#00A3BFC5$��25(�6�   $��Segoe UI Light)�6�   $��Right=�6�   $	��328��6�    � 5   
   -   5          �Name$
 frm1��5      $��Frame��6   $��339,31,37,125q�6.   $��1��6E   
�������	  � NavigationUIVisibility$	 Hidden=�6f   �� 5   
   -   5        $ 	btnLogout��5      $��
Выйти��6$   $��	0,55,37,0q�64   $	��Top=�6G   $��Right=�6_   $	��117��6{   ���	#FFE87ED9���	#FFDFDFEE$��16(�6�   $��Segoe UI Light)�6�   5      5      