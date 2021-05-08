Program jest napisany w c# i jego zadaniem jest modyfikacja zdjecia przy pomocy wyrówynwanie histogramu, filtru uśredniającego lub filtru gaussa. Efekt wyrównania histogramu otrzymuje korzystając z wcześniej przygotowanej tablicy tonalnej. Wartość elementu i-tego takiej tablicy tonalnej wyliczamy ze wzoru  
![image](https://user-images.githubusercontent.com/80325475/117549011-57a4b000-b038-11eb-9c6b-04dd39afce98.png)  
Gdzie:
```
D(i) - suma poprzednich wartości z tablicy R,G,lub B (w zależności którą z nich liczymy)
D0 - najmniejsza wartość z tablicy
```
Po otrzymaniu takich tablic zwracamy nowe zdjęcie (do dolnego boxu) o składowych z tablic wyżej wymienionych.  
Filtry gaussa i uśredniania do działania wykorzystuja wartość promienia z okienka do wartości liczbowej. W filtrze uśredniania wszystkie wartości maski są równe podanemu promienowi i następnie przy pomocy takiej maski licze wartości nowych składowych przy pomocy wzoru:
```
            for (int x = 1; x < szerokosc_obrazu - 1; x++)
            {
                for (int y = 1; y < wysokosc_obrazu - 1; y++)
                {
                nowa_składowa=0
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            nowa_składowa += stara_składowa * maska[i, j]
                        }
                    }
                }
            }
```
Oprócz samego liczenia składowej są jeszcze stworzone zabepieczenia żeby składowa nie była większa niż 255 oraz mniejsza niż 0. Do filtrów wprowadziłem normalizacje maski która polega na tym że jeśli suma wszystkich elementów tablicy maski jest różna od 0 to wtedy nowe składowe przyjmują wartość samych siebie podzielonych przez wartość normalizacji
```
                    if (wartość_normalizacji != 0)
                    {
                        r = r / wartość_normalizacji;
                        g = g / wartość_normalizacji;
                        b = b / wartość_normalizacji;
                    }
```
