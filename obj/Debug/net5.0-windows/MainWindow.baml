   M S B A M L   `   `   `  ����M  IVacationCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VacationCalculatorVacationCalculator  5   	   #    VacationCalculator.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:VacationCalculator     5   	     � Title$  Vacation Time Calculator��5   	   $	��450��6*   $	��800��67   .��5	      � .+�5
   
   �� -   5         ��Name$ title��5
      $��Vacation Time Calculator��6   $
��Left=�6B   $��Center=�6]   $��
117,21,0,0q�6�   $	��Top=�6�   $	��529��6�   $��22(�6�   
����d�$��Source Sans Pro)�6�   $��Normal"�6   �� 5   
   -   5        $ startDateLabel��5      $��Start Date: ��6(   $
��Left=�6?   $��	36,59,0,0q�6Z   $	��Top=�6m   $��20(�6�   $��Source Sans Pro)�6�   $��Normal"�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ startDatePicker��5      $
��Left=�6.   $��
133,59,0,0q�6I   $	��Top=�6]   $��20(�6�    J� RenderTransformOrigin$ 
0.55,0.469&�6�   $��Source Sans Pro)�6�   �� 5   
   -   5        $ totalHoursLabel��5      $.��(Total Vacation Earned as of last month: ��6)   $
��Left=�6\   $��	36,99,0,0q�6w   $	��Top=�6�   $��20(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5        $ totalHoursValueLabel��5      $��--��6.   $
��Left=�6;   $��
373,99,0,0q�6V   $	��Top=�6j   $��20(�6�   $��Source Sans Pro)�6�   $	��299��6�   �� 5   
   -   5        $ currentHoursLabel��5      $+��%What are your current vacation horus?��6+   $
��Left=�6[   $��
36,139,0,0q�6v   $	��Top=�6�   $��37��6�   $	��352��6�   $��20(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5         ��Name$ currentHoursTextBox��5      $
��Left=�6/   $��359,139,0,0q�6J   $�� ��6_    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $��89��6�   $��20(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5        $ futureDateLabel��5      $��Future Date:��6)   $
��Left=�6@   $��
35,219,0,0q�6[   $	��Top=�6o   $��20(�6�   $��Source Sans Pro)�6�     5   
   -	   5        $ futureDatePicker��5      $
��Left=�6/   $��143,218,0,0q�6J   $��20(�6�   $��Source Sans Pro)�6�   $	��Top=�6�   �� 5   
   -
   5        $ plannedTimeOffLabel��5      $0��*Number of vacation days planned to be used��6-   $
��Left=�6b   $��
35,259,0,0q�6}   $	��Top=�6�   $��20(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5        $ plannedTimeOffTextBox��5      $
��Left=�61   $��416,259,0,0q�6L   $��0��6a   $
 Wrap=�6j   $	��Top=�6~   $��58��6�   $��20(�6�   $��Source Sans Pro)�6�   �� 5   
   -   5        $ totalVacationLeftlabel��5      $��Total Vacation Left: ��60   $
��Left=�6P   $��
36,319,0,0q�6k   $	��Top=�6   $��20(�6�   $��Source Sans Pro)�6�   $
��Bold"�6�   �� 5   
   -   5        $! totalVacationLeftValueLabel��5      $��0��65   $
��Left=�6A   $��209,319,0,0q�6\   $	��Top=�6q   $��20(�6�   $��Source Sans Pro)�6�   $
��Bold"�6�   $	��309��6�   �� 5!   
   -   5        $ 
errorLabel��5!      $��Something went wrong!��6$   $
��Left=�6D   $��Center=�6_   $��117,363,0,0q�6�   $	��Top=�6�   $	��529��6�   $��22(�6�   
���  ��$��Source Sans Pro)�6�   $��Normal"�6�   5"      5#      