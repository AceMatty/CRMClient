   M S B A M L   `   `   `  ����D  @clientCrm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:clientCrm	clientCrm  5   	       clientCrm.RegistrForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:clientCrm     5   	   @
extensions)using:Microsoft.Toolkit.Uwp.UI.Extensions     5   	     � Title$  Регистрация��5	      $	��771��6   $	��500��6)   ���	#FF402E61 � WindowStartupLocation$ CenterScreen=�6L    � 
ResizeMode$ NoResize=�6q   .��5
      � .+�5   
   �� -   5         ��Name$ txtLogin��5      $
��Left=�6$   $��34��6?   $��	6,202,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��246��6�   ���	#FF9F93E0
�������$��20(�6�   $��Segoe UI Light)�6�   
�������6�   �� 5   
   $��
Логин��6   $
��Left=�6    $��
10,159,0,0q�6;   $	��Top=�6O   $��38��6g   $	��242��6s   $��23(�6   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   $D��>Регистрация нового 
пользователя��6   $
��Left=�6D   $��6,24,0,0q�6_   $	��Top=�6q   $	��118��6�   $	��478��6�   $��35(�6�   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   -   5        $ txtPass��5      $
��Left=�6#   $��34��6>   $��	6,279,0,0q�6J   $
 Wrap=�6]   $	��Top=�6q   $	��246��6�   ���	#FF9F93E0
�������$��20(�6�   $��Segoe UI Light)�6�   
�������6�   �� 5   
   $��Пароль��6   $
��Left=�6!   $��
10,236,0,0q�6<   $	��Top=�6P   $��38��6h   $	��242��6t   $��23(�6�   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   -   5        $ txtFio��5      $
��Left=�6"   $��34��6=   $��	6,356,0,0q�6I   $
 Wrap=�6\   $	��Top=�6p   $	��464��6�   ���	#FF9F93E0
�������$��20(�6�   $��Segoe UI Light)�6�   
�������6�   �� 5   
   $��ФИО��6   $
��Left=�6   $��
10,313,0,0q�69   $	��Top=�6M   $��38��6e   $	��242��6q   $��23(�6}   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   -   5         ��Name$ cmbBox��5      $
��Left=�6#   $��	6,602,0,0q�6>   $	��Top=�6Q   $	��246��6i   $��34��6u    �� SelectedIndex$ 0��6�   $��20(�6�   $��Segoe UI Light)�6�   ���	#FF9F93E0.@�5      �� $#��Обычный аккаунт��6   $��Segoe UI Light)�65   �� 5      $ ��Администратор��6   $��Segoe UI Light)�63   �� 5      $��Segoe UI Light)�6   5      �� 5   
   $��Тип аккаунта��6   $
��Left=�6'   $��
10,559,0,0q�6B   $	��Top=�6V   $��38��6n   $	��242��6z   $��23(�6�   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   -   5         ��Name$ 
btnRegistr��5      $��Регистрация��6%   $
��Left=�6;   $��
10,676,0,0q�6V   $	��Top=�6j   $	��242��6�   $��37��6�   ���	#FFE87ED9
�������$��Segoe UI Light)�6�   $��20(�6�   ���	#FFCDB1F64  .System.Windows.Automation.AutomationProperties   HelpText$  Вход в систему��6  65  �� 5   
   -   5        $ txtEmail��5      $
��Left=�6$   $��34��6?   $��	6,438,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $	��464��6�   ���	#FF9F93E0
�������$��20(�6�   $��Segoe UI Light)�6�   
�������6�   �� 5   
   $��Еmail��6   $
��Left=�6    $��
10,395,0,0q�6;   $	��Top=�6O   $��38��6g   $	��242��6s   $��23(�6   $��Segoe UI Light)�6�   ���	#00000000
�������6�   �� 5   
   -   5        $ txtPhone��5      $
��Left=�6$   $��34��6?   $��	6,520,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $	��246��6�   ���	#FF9F93E0
�������$��20(�6�   $��Segoe UI Light)�6�   
�������	   IsRowHeader	 . 6�   �� 5   
   $��Телефон��6   $
��Left=�6"   $��
10,477,0,0q�6=   $	��Top=�6Q   $��38��6i   $	��242��6u   $��23(�6�   $��Segoe UI Light)�6�   ���	#00000000
�������6�   5      5      