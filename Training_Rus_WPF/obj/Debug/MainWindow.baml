   M S B A M L   `   `   `  ����5  1Тренажер по русскому языку!    Training_Rus_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  GlobalWindow��5	   	    � Icon$ pen.ico��5
   	   $	��965��5   	   $	��490��5   	    � Title$7 1Тренажер по русскому языку��5   	   $��619.5��6,   $��962.5��6;    � 	Resources 5         
oProgramme �� Property �� Value  Mybutton  
mainLabels �� 
TargetType  
Circle_btn �� CornerRadius �� Triggers	 P� Property
 P� Value  for_menu_image �� 
TargetType �� Triggers��%  &	        &	 �     &	 w    &	 C    &	 \    �� 5   
   .�5      ��  � ��$ 22(�61   �� 5       �@��TextAlignment$ Center=�69   �� 5       � ��$ 0,2,0,0q�6/   �� 5       � ��$$ Bahnschrift SemiBold Condensed)�65   5      �� 5   
   .�5      ��  � ��$$ Bahnschrift SemiBold Condensed)�63   �� 5       � ��$$ Bahnschrift SemiBold Condensed)�63   5      �� 5   
   .�5       ��  � ��$$ Bahnschrift SemiBold Condensed)�63   �� 5!       � ��$ 32(�61   �� 5"       � ��$ Center=�6<   �� 5#       � ��
 �   �63   5$      �� 5(   
   " ��6   .R�5)      �� $ 50��6   #��z��6'   $��0,0,0,0q�5*      #��z��5+      #��z��5,      #��z��5-      ._�5.      �� #��z��6!   #��z��5/   !   #��z��50   !   #��z��51   !   52       53      P� 54      	 �@J�IsMouseOver
 . . �55      ��  � ��
 �����68   �� 56       � ��
 �����63   57      P� 58      	 � ��
 . . �59      ��  � �� �#A6A6A668   �� 5:       � ��
 �����63   �� 5;       � ��$ 2,0,0,0q�6@   5<      5>      �� 5@   
   " ��6'    5A      P� 5B      	 �@J�IsMouseOver
 . . �5C      ��  � ��
 �����63   5D      5F      5H      .��5J      � -   5        $��MainGrid��5J      $��0,0,0,0q�6   .+�5N   
   � -   5         �Name$ Grid_for_tests��5N      ���#616375.+�5Q      � -   5        $ 
For_text_1��5Q      $��70,0,0,0q�6'   ���#616375.+�5T      �� -   5         ��Name$ text1��5T   J   $
��Auto=�6    �� 
IsReadOnly .  � Cursor$	 Pen��6p   $��50(�6    �� TextWrapping$
 Wrap=�6�   $��	0,20,0,50q�6�   .��6�   5V      � 5X      $��Bottom=�6   $��50��64   .+�5Y      �� -   5         ��Name$ sbros1��5Y      $
 Hand��6-   $��Сначала��6;   $
��Left=�6O   $��400,5,137,0q�6j   $	��Top=�6   $	��185��6�   $��37��6�   �� 5[      -   5        $ 	Proverka1��5[      $
 Hand��60   $��Проверить��6>   $
��Left=�6T   $��200,5,335,0q�6o   $	��Top=�6�   $	��185��6�   $��37��6�   �� 5\      -   5        $ back1��5\      $
 Hand��6,   $��Шаг назад��6:   $
��Left=�6N   $��	0,5,531,0q�6i   $	��Top=�6|   $	��185��6�   $��37��6�   $
��Undo��5]   I   ��6   ��  �� ElementName$ text1��6I   5_      � 5`      -	   5         �Name$ wrap1��5`   �   ��. $
��Auto=�6A   $y�Hidden=�6q   
������� � Orientation$ 
Horizontal=�6�   $��	0,20,0,50q�6�   �� 5a      -
   5         ��Name$
 lbl1��5a      $y�Hidden=�6&   $��Bottom=�6:   $��Right=�6U   
���""��$��Ваша оценка��6�   
�������$��0,0,0,0q�6�   $��35(�6�   $��50��6�   6�   5b      � 5d      -   5        $ 
For_text_2��5d      $y�	Collapsed=�6'   $��70,0,0,0q�6?   ���#616375.+�5e      �� -   5        $ text2��5e   J   $
��Auto=�6    . $	 Pen��6k   $��50(�6x   $
 Wrap=�6�   $��	0,20,0,50q�6�   � 5f      $��Bottom=�6   $��50��64   .+�5g      �� -   5        $ sbros2��5g      $
 Hand��6-   $��Сначала��6;   $
��Left=�6O   $��400,5,137,0q�6j   $	��Top=�6   $	��185��6�   $��37��6�   �� 5i      -   5        $ 	Proverka2��5i      $
 Hand��60   $��Проверить��6>   $
��Left=�6T   $��200,5,335,0q�6o   $	��Top=�6�   $	��185��6�   $��37��6�   �� 5j      -   5        $ back2��5j      $
 Hand��6,   $��Шаг назад��6:   $
��Left=�6N   $��	0,5,531,0q�6i   $	��Top=�6|   $	��185��6�   $��37��6�   $
��Undo��5k   I   ��6   �� $ text2��6I   5m      � 5n      -   5        $ wrap2��5n   �   ��. $
��Auto=�6A   $y�Hidden=�6q   
�������$ 
Horizontal=�6�   $��	0,20,0,50q�6�   �� 5o      -   5        $
 lbl2��5o      $y�Hidden=�6&   $��Bottom=�6:   $��Right=�6U   
���""��$��Ваша оценка ��6�   
�������$��0,0,0,0q�6�   $��35(�6�   6�   5p      � 5r      -   5        $ 
For_text_3��5r      $y�	Collapsed=�6'   $��70,0,0,0q�6@   ���#616375.+�5s      �� -   5        $ text3��5s   J   $
��Auto=�6    . $	 Pen��6k   $��50(�6x   $
 Wrap=�6�   $��	0,20,0,50q�6�   � 5t      $��Bottom=�6   $��50��64   .+�5u      �� -   5        $ sbros3��5u      $
 Hand��6-   $��Сначала��6;   $
��Left=�6O   $��400,5,137,0q�6j   $	��Top=�6   $	��185��6�   $��37��6�   �� 5w      -   5        $ 	Proverka3��5w      $
 Hand��60   $��Проверить��6>   $
��Left=�6T   $��200,5,335,0q�6o   $	��Top=�6�   $	��185��6�   $��37��6�   �� 5x      -   5        $ back3��5x      $
 Hand��6,   $��Шаг назад��6:   $
��Left=�6N   $��	0,5,531,0q�6i   $	��Top=�6|   $	��185��6�   $��37��6�   $
��Undo��5y   I   ��6   �� $ text3��6I   5{      � 5|      -   5        $ wrap3��5|   �   ��. $
��Auto=�6A   $y�Hidden=�6q   
�������$ 
Horizontal=�6�   $��	0,20,0,50q�6�   �� 5}      -   5        $
 lbl3��5}      $y�Hidden=�6&   $��Bottom=�6:   $��Right=�6U   
���""��$��Ваша оценка ��6�   
�������$��0,0,0,0q�6�   $��35(�6�   6�   5~      � 5�      -   5        $ 
For_text_4��5�      $y�	Collapsed=�6(   $��70,0,0,0q�6?   ���#616375.+�5�      �� -   5        $ text4��5�   J   $
��Auto=�6   $	 Pen��6Y    . $��50(�6x   $
 Wrap=�6�   $��	0,20,0,50q�6�   � 5�      $��Bottom=�6   $��50��64   .+�5�      �� -   5        $ sbros4��5�      $
 Hand��6-   $��Сначала��6;   $
��Left=�6O   $��400,5,137,0q�6j   $	��Top=�6   $	��185��6�   $��37��6�   �� 5�      -   5        $ 	Proverka4��5�      $
 Hand��60   $��Проверить��6>   $
��Left=�6T   $��200,5,335,0q�6o   $	��Top=�6�   $	��185��6�   $��37��6�   �� 5�      -   5        $ back4��5�      $
 Hand��6,   $��Шаг назад��6:   $
��Left=�6N   $��	0,5,531,0q�6i   $	��Top=�6|   $	��185��6�   $��37��6�   $
��Undo��5�   I   ��6   �� $ text4��6I   5�      � 5�      -   5        $ wrap4��5�   �   ��. $
��Auto=�6A   $y�Hidden=�6q   
�������$ 
Horizontal=�6�   $��	0,20,0,50q�6�   �� 5�      -   5        $
 lbl4��5�      $y�Hidden=�6&   $��Bottom=�6:   $��Right=�6U   
���""��$��Ваша оценка ��6�   
�������$��0,0,0,0q�6�   $��35(�6�   6�   5�      � 5�      -    5        $ 
For_text_5��5�      $y�	Collapsed=�6'   $��70,0,0,0q�6>   ���#616375.+�5�      �� -!   5        $ text5��5�   J   $
��Auto=�6   $	 Pen��6Y    . $��50(�6x   $
 Wrap=�6�   $��	0,20,0,50q�6�   � 5�      $��Bottom=�6   $��50��64   .+�5�      �� -"   5        $ sbros5��5�      $
 Hand��6-   $��Сначала��6;   $
��Left=�6O   $��400,5,137,0q�6j   $	��Top=�6   $	��185��6�   $��37��6�   �� 5�      -#   5        $ 	Proverka5��5�      $
 Hand��60   $��Проверить��6>   $
��Left=�6T   $��200,5,335,0q�6o   $	��Top=�6�   $	��185��6�   $��37��6�   �� 5�      -$   5        $ back5��5�      $
 Hand��6-   $��Шаг назад��6;   $
��Left=�6O   $��	0,5,531,0q�6j   $	��Top=�6}   $	��185��6�   $��37��6�   $
��Undo��5�   J   ��6   �� $ text5��6J   5�      � 5�      -%   5        $ wrap5��5�   D   $y�Hidden=�6   
�������$ 
Horizontal=�6S   $��	0,20,0,50q�6l   �� 5�      -&   5        $
 lbl5��5�      $y�Hidden=�6&   $��Bottom=�6:   $��Right=�6U   
���""��$��Ваша оценка ��6�   
�������$��0,0,0,0q�6�   $��35(�6�   6�   5�      �� 5�      -'   5         ��Name$ 
menu_stack��5�      $
 Hand��6-    �� Orientation$ 
Horizontal=�6<   $
��Left=�6U   $	��Top=�6p   $��70��6�   $��65��6�   ���#616375.+�5�      �� -(   5         ��Name$ 	menuImage��5�   a   $
��Left=�6   $
 Hand��68   $��Center=�6F   $��71��6t   $��64��6   5�      �� 5�      -)   5        $
��Left=�5�      $
 Hand��65   $��Center=�6C   $��Теория��5�      $��65��6#   $��0,0,0,0q�6/   $��70��6A   6L   �� 5�      -*   5        $
��Left=�5�      $
 Hand��66   $��Center=�6D   $��
Назад��5�      $��65��6"   $��0,0,0,0q�6.   $��70��6@   6K   5�      �� 5�      $��0,64,0,0q�6   $��70��6,   $
��Left=�68   ���#616375.+�5�      �� -+   5        $ 
open_text1��5�   I   #��[ 5�      $
 Hand��6@   $
��Left=�6N   $��25(�6i   $��Bottom=�6w   $��1��5�      $��50��6   $��	10,25,0,0q�6*   $��50��6>   6I   �� 5�      -,   5        $ 
open_text2��5�   I   #��[ 5�      $
 Hand��6A   $
��Left=�6O   $��25(�6j   $��Bottom=�6x   $��2��5�      $��50��6   $��	10,10,0,0q�6*   $��50��6>   6I   �� 5�      --   5        $ 
open_text3��5�   J   #��[ 5�      $
 Hand��6@   $
��Left=�6N   $��25(�6i   $��Bottom=�6w   $��3��5�      $��50��6   $��	10,10,0,0q�6*   $��50��6>   6J   �� 5�      -.   5        $ 
open_text4��5�   J   #��[ 5�      $
 Hand��6@   $
��Left=�6N   $��25(�6i   $��Bottom=�6w   $��4��5�      $��50��6   $��	10,10,0,0q�6*   $��50��6>   6J   �� 5�      -/   5        $ 
open_text5��5�   I   #��[ 5�      $
 Hand��6@   $
��Left=�6N   $��25(�6i   $��Bottom=�6w   $��5��5�      $��50��6   $��	10,10,0,0q�6*   $��50��6>   6I   5�      �� 5�      -0   5        #��[ 5�      $
��Left=�6<   $��25(�6W   $��Bottom=�6e   $��50��5�      $��5,0,0,0q�6   $��	10,0,0,10q�61   $��50��6E   .��5�      �� $��file.png��6   $��35��6*   $��35��65   5�      5�      � 5�   
   -1   5        $ 	enterGrid��5�   $   $y�Visible=�6   $��0,0,0,0q�67   ���#616375.+�5�      �� $��bookWall.png��6   $��	0,200,0,0q�6*   �� 5�      -2   5        $	 Fio��5�   >   $y�	Collapsed=�6   $��0��6.   $��ФИО��5�      $��25��6    �� TextAlignment$
 Left=�6$   $��20(�69   $��5,0,0,0q�5�      $��Center=�6    $	��200��6=   $��Bottom=�5�      $��0,0,0,75q�6(   #��[ 6:   �� 5�      -3   5        $	 Pas��5�   =   $y�	Collapsed=�6   $��0��6-   $��Группа��5�      $��25��6   $
 Left=�6(   $��20(�6=   $��5,0,0,0q�5�      $��Center=�6   $	��200��6<   $��Bottom=�5�      $��0,0,0,45q�6(   #��[ 6:   �� 5�      -4   5        $ 	Begin_BTN��5�      $
 Hand��6(   $��0��66   $��Приступить��5�      $��30��6$   $��20(�62   $��Center=�5�      $	��200��6*   #��[ 67   $��Bottom=�5�      $��0,0,0,10q�6(   6:   �� 5�      -5   5        $ Mlabel1��5�      #��[ 5�      $��0,35,0,0q�6:   $	��Top=�6L   $7��1ГБПОУ ВО "Кольчугинский ПК"��5�      �� 5�      -6   5        $ Mlabel2��5�      #��[ 5�      $��50(�68   $��261,136,261,323q�6H   $��Center=�6a   $U��OТренажер по дисциплине 
          "Русский язык"��5�      �� 5�      -7   5        $ Mlabel3��5�      #��[ 5�      $��Right=�68   $��0,350,89,187q�6V   $��Center=�6l   $:��4Преподаватель: Комарова М. Ю.��5�      $��52��6>   5�      � 5�   
   -8   5        $ instrukciya��5�   4   $y�Visible=�6   $
 Hand��6$   $	��Top=�6I   $��Right=�6a   $	��200��6}   $��20��6�   
���� ��.+�5�      � -9   5        $
 ins1��5�   (   $y�Visible=�6   
�������$��0,20,0,0q�6I    � ColumnDefinitions 5�      �� 5      $	��400 �6'   �� 5     $
��291* �6'    � RowDefinitions 5     �� 5     $
��500* �6$   �� 5     $��80 �6$   .+�5     �� $��0��6   $
��Wrap=�6-   $��25(�6A   $
��auto��6O   Титульная форма�� 5
     0.1) информация о программе;�� 5     ��2) кнопка "Приступить", по нажатию которой вы можете начать работу с программой;�� 5     CA3)инструкция по работе с программой.5     �� 5     $��1��6   $��меню.jpg��6(   $��10,10q�6:   �� 5     -:   5        $ btnNext1��5     $
 Hand��6+   $
��Left=�69   $��1��6T   $��1��6d   $	��200��6q   $��50��6}   $��0,0,0,10q�6�   .��5     �� $��rightArrow.png��6   5     5     � 5     -;   5        $
 ins2��5  '   $y�Hidden=�6   
�������$��0,20,0,0q�6H    5     �� 5     $	��400 �6'   �� 5     $
��291* �6'    5     �� 5     $
��500* �6$   �� 5      $��80 �6$   .+�5#     �� $��0��6   $
��Wrap=�6,   $��21(�6@   $
��auto��6N   %#Форма тестирования�� 5&     861) меню для перехода по формам;�� 5(     0.2) информация о программе;�� 5*     DB3) инструкция по работе с программой;�� 5,     %#4) варианты текстов;�� 5.     db5) позволяет пройти текст снова и перемешивает тексты;�� 50     866) отмена последнего действия;�� 52     #!7) проверка текста;�� 54     758) возврат к исходному тексту;�� 56     ��9) окно для вставки символа (вызывается при нажатии по знаку подчеркивания"_" или при нажатии по последниму символу слова).5;     �� 5<     $��1��6   $��тест.jpg��6(   $��10,10q�6:   �� 5=     -<   5        $ btnBack1��5=     $
 Hand��6+   $��Right=�69   $��0��6U   $��1��6e   $	��200��6r   $��50��6~   $��0,0,0,10q�6�   .��5>     �� $��leftArrow.png��6   5?     �� 5@     -=   5        $ btnNext2��5@     $
 Hand��6+   $
��Left=�69   $��1��6T   $��1��6d   $	��200��6q   $��50��6}   $��0,0,0,10q�6�   .��5A     �� $��rightArrow.png��6   5B     5C     � 5E     ->   5        $
 ins3��5E  '   $y�Hidden=�6   
�������$��0,20,0,0q�6H    5F     �� 5G     $	��400 �6'   �� 5H     $
��291* �6'    5J     �� 5K     $
��500* �6$   �� 5L     $��80 �6$   .+�5O     �� $��0��6   $
��Wrap=�6-   $��25(�6A   $
��auto��6O   Форма с теорией�� 5Q     ,*1) назад к тестированию;�� 5S     2) список теории;�� 5U     '%3) контекстный поиск;�� 5W     /-4) поле для чтения текста.5Z     �� 5[     $��1��6   $��Теория.jpg��6(   $��10,10q�6<   �� 5\     -?   5        $ btnBack2��5\     $
 Hand��6+   $��Right=�69   $��0��6U   $��1��6e   $	��200��6r   $��50��6~   $��0,0,0,10q�6�   .��5]     �� $��leftArrow.png��6   5^     5`     �� 5c     -@   5        $ Bloc_instrukcii��5c     $��Right=�61   $	��Top=�6M   $	��200��5d     $��20��6$    �� Padding$ 	10,1,10,0q�60   
������� �� TextAlignment$ Center=�6W   $
��Bold"�5e     $��Italic$�6&   $$��Bahnschrift SemiBold Condensed)�69   $��17(�6e   �� 6t   $�Инструкция��6x   6�   5g     � 5i  
   -A   5        $ spravka��5i     $
 Hand��6    $	��Top=�6.   $��Center=�6F   $	��200��6c   $��20��6o   
���� ��.+�5l     �� -B   5        $ Text_spravki��5l     $��Stretch=�6/   $��Stretch=�6M   
�������$��0,19,0,0q�5m     $��Visible=�6*   .+�5n     �� #��[  6   �� 6A   $o�iПрограмма разработана в рамках курсового проектирования��6E   6�   �� 5o     #��[  6   �� 6B   $s�mпо МДК 03.01 "Технология разработки программного обеспечения"��6F   6�   �� 5p     #��[  6   �� 6A   $B�<студентом группы П-16 Бабаевым Р.М��6E   6r   �� 5q     #��[  6   �� 6A   $V�Pруководитель курсового проекта Фролова Г.Н.��6E   6{   �� 5r     #��[  6   �� 6A   $P�JПреподаватель-консультант: Комарова М.Ю.��6E   6x   �� 5s     #��[  6   $��Bottom=�6@   �� 6]   $�2019г��6a   6q   5t     �� 5v     -C   5        $ Bloc_spravka��5v     $��Center=�6.   $	��Top=�6K   $	��200��5w     $��20��6$   $ 	10,1,10,0q�60   
�������$ Center=�6W   $
��Bold"�5x     $��Italic$�6&   $$��Bahnschrift SemiBold Condensed)�69   $��17(�6e   �� 6t   $�О программе��6x   6�   5z     � 5�  
   -D   5        $ 
theoryGrid��5�     $��Right=�6#   $��0��6?   .+�5�     � -E   5        $ listBox��5�  �   $	��250��6   ���#616375$��0,25,0,0q�68   $
��Left=�6J   $��Stretch=�6e   .+�5�     �� -F   5         ��Name$ scrollViewer��5�     $	��253��66   $
��Auto=�6B   $
��Left=�5�     $��0,0,0,27q�6:   .��5�     �� -G   5        $ stack��5�  !   ���#616375��5�     �� *Width+$ listBox����5�     �� *Height+$ listBox��5�     �� 5�     $��Bottom=�6   $��0,0,0,27q�67   �� 5�     -H   5        $ back_to_test��5�     $��Bottom=�62   $��0,0,0,0q�6M   $��27��6^   $
 75,0q�6j   $��20(�6y   
��������� 5�  K   $�
Назад��6O   6_   5�     � 5�     $��27��6   $	��Top=�5�     $��0,0,0,0q�6)   $
��Left=�6:   $	��250��5�     .+�5�     �� -I   5        $ 	searchBox��5�     $��27��6-   $��Stretch=�6:   $��Stretch=�6V   $��0,0,0,0q�5�     $��
Поиск��6+   $��16(�68   ���#616375
����������#6163756�   5�     � 5�     ���#616375$��Right=�6*   $��	250,0,0,0q�6F   .+�5�     �� -J   5        $ 	tema_name��5�     $��Stretch=�6/   $��27��6M   $	��Top=�6Y   
�������$ 10,5,0,0q�6�   �� 6�   $�Тема��6�   6�   �� 5�     -K   5          ��Name$  TextDocumenta��5�  I    . ���#E7E9FE"! �� VerticalScrollBarVisibility$
! Auto=�6u   $" �� HorizontalScrollBarVisibility$" Visible=�6�   $��0,27,0,0q�6�   5�     �� 5�     $	��Top=�6   $��0,27,0,0q�60   5�     5�     5�     