Program został napisany w c# i pozwala na zmiane kontrastu zdjęcia które w niego wczytamy oraz pokazuje histogramy zdjęcia ze zmienionym kontrastem. Przy pomocy przycisku "Wczytaj zdjęcie" możemy wczytać zdjęcie do programu. Pod napisem "Zmiana kąta zachylenia prostej na wykresie" znajdują się Dwa przyciski oraz dwa miejsca do wpisania liczb. Przyciski opowiadają za zwiększenie lub zmniejszenie kontrastu o wartość podaną w pustym polu na lewo od przycisku. Kontrast przy tych przyciskach jest zmienany według wzoru z Wariantu 1 czyli:  
![image](https://user-images.githubusercontent.com/80325475/116794564-2a9f4d00-aace-11eb-890f-2aa0298c83c7.png)  
Następnie idąc w prawo mamy przyciski pod i miejsca na wpisanie wartości pod napisem "Zmiana kąta oddzielnie dla jasnych i ciemnych". Przyciski działają podobnie jak te wyżej wymienione ale korzystają ze wzoru z Wariantu 2 czyli:  
![image](https://user-images.githubusercontent.com/80325475/116794593-6cc88e80-aace-11eb-8b6e-006b994356bd.png)  
W każdym z tych funkcji istnieje zabezpieczenie polegającym na:  
```
if (składowa >= 0 && składowa <= 255)
   ustaw nową składową o wartości która wyszła ze wzoru
```
Do tworzenia i rysowania histogramów składowych R G i B wykorzysuje funkcje histogram w której w pierwszych trzech for-ach (for-ach z x i y) zapisuje wartości(wysokości) kolumn histogramu do tablic a w kolejnych (for-ach z i) rysuje histogramy.  
Jako innowacje uznaje:  
```
1. Przycisk do przeniesienia zdjęcie po zmiane kontrastu na zdjęcie z którego wychodzimy (przycisk <<<<< na środku aplikacji) 
   dzięki czemu możemy zmienć kontrast zdjęciu któremu już zmieniliśmy kontrast
2. Możliwośc zapisu zdjęcia po zmianie kontrastu oraz każdego z histogramów jako plik
3. Wykorzystanie obu wariantów wzorów
```
