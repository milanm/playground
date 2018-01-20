// random.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <math.h>
#include <time.h>
#include <iostream>
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/timeb.h>

using namespace std;

class TSlucajni{
private:
float u[97], c, cd, cm;
int i97, j97;

public:
TSlucajni(int,int); //randomize
float Rnd(void); // interval [0,1)
inline int Ceo(int n ) // interval [0,n] celih
{return (n+1)*Rnd();}
int Interval(int,int); // interval celih [a,b]
float Interval(float,float); // interval realnih [a,b)
};
/*
randomize1
----------
* Ovo je inicijalizaciona rutina za generator slucajnih brojeva: rnd1
* Seed varijable moraju uzimati sledece opsege vrednosti:
0 <= IJ <= 31328
0 <= KL <= 30081
t Za proveru random generatora: uzeti IJ = 1802 & KL = 9373. Zatim treba
generisati 20 000 slucajnih brojeva. Sledecih sest brojeva pomnoženih sa
4096*4096 bi trebalo da budu:
6533892.0 14220222.0 7275067.0 6172232.0 8354498.0 10633180.0 */


TSlucajni::TSlucajni (int ij=time(0)%31328, int kl=time(0)%30081)
{
float s, t;
int i, j, k, l, m;
int ii, jj;

i = fmod(ij/177.0, 177.0) + 2;
j = fmod(ij , 177.0) + 2;
k = fmod(kl/169.0, 178.0) + 1;
l = fmod(kl , 169.0);

for (ii=0; ii<=96; ii++ )
{
s = 0.0;
t = 0.5;
for (jj=0; jj<=23; jj++ )
{
m = fmod( fmod(i*j,179.0)*k , 179.0 );
i = j;
j = k;
k = m;
l = fmod( 53.0*l+1.0 , 169.0 );
if ( fmod(l*m,64.0) >= 32)
s = s + t;
t = 0.5 * t;
}
u[ii] = s;
}

c = 362436.0 / 16777216.0;
cd = 7654321.0 / 16777216.0;
cm = 16777213.0 / 16777216.0;

i97 = 96;
j97 = 32;

return;
}

/*
rnd1
----
* Generator slucajnih brojeva u opsegu: [0-1)
* Ovo je NAJBOLJI dostupni generator slucajnih brojeva. Prolazi SVE testove
za generatore slucajnih brojeva i ima periodu od 2^144 (!). Da bi dao
ispravne rezultate mantise u float point prikazu brojeva moraju biti
najmanje 24 bitne. Pokazuje izuzetnu stabilnost pri ogromnim serijama.
To sam proverio testom Romanovskog za najmanje 10^8 generisanih brojeva.
* Zapazi da su JEDINE matematicke operacije sabiranje i oduzimanje
(iako ima i float-pointing matematike)->BRZINA! */

float TSlucajni::Rnd(void)
{
float uni;

uni=u[i97]-u[j97];
if (uni < 0.0) uni+=1.0;
u[i97]=uni;
i97--;
if (i97 < 0) i97=96;
j97--;
if (j97 < 0) j97=96;
c-=cd;
if (c < 0.0) c+=cm;
uni-=c;
if (uni < 0.0) uni+=1.0;
return (uni);
}

int TSlucajni::Interval(int a,int b){
if( a == b ) return a;
else if(a>b) {int c=a;
a=b;b=c;
}
return a+Ceo(b-a);
}

float TSlucajni::Interval(float a, float b){
if( a == b ) return a;
else if(a>b) {float c=a;
a=b;b=c;
}
return a+(b-a)*Rnd();
}


int _tmain(int argc, _TCHAR* argv[])
{
	TSlucajni *slucajni = new TSlucajni();
	TSlucajni *seed = new TSlucajni();

	cout << "**************************************" << endl;
	cout << "* Program za generisanje kombinacije * " << endl;
	cout << "* slucajnih brojeva za LOTO 7 od 39  *" << endl;
	cout << "* ---------------------------------- *" << endl;
	cout << "* Autor: Milan Milanovic             *" << endl;
	cout << "**************************************\n\n" << endl;
	int br; int min = 1, max = 39;
	int niz[7];
	cout << "Koji broj kombinacija zelite: "; cin >> br; cout << endl;
	if( (br < 1) || (br > 1000) )
	{
		cout << "Greska: broj mora biti u intervalu [1-1000]!" << endl;
		cout << "Pritisnite bilo sta za KRAJ!" << endl; getch(); exit(0);
	}

	for (int i = 0; i < br; i++)
	{
		cout << "\nKombinacija " << i+1 << ".: ";
		for(int j = 0; j < 7; j++)
		{
		   int ok = 0;
		   while(!ok)
		   {
			   int big_niz[20000];
			   for(int nn=0;nn<20000;nn++) big_niz[nn] = slucajni->Interval(min,max); 
			
			   int generisani = big_niz[slucajni->Interval(0,19999)];
	
			   for(int k = 0; k < j; k++)
			   {
				ok = 1;
				if(niz[k] == generisani) { ok = 0; break; }
			   }
			   if(j == 0) ok = 1;
			   if(ok) niz[j] = generisani;

			   delete slucajni; slucajni = 0;
			   slucajni = new TSlucajni(seed->Interval(0,31328), seed->Interval(0,30081));
		   }
		}
		// sort
		for(j = 0; j < 6; j++)
			for (int k = j+1; k < 7; k++)
				if (niz[j] > niz[k]) { int temp = niz[j]; niz[j] = niz[k]; niz[k] = temp; }

		// ispis kombinacije
		for(j = 0; j < 7; j++) printf("%2d ",niz[j]);//cout << niz[j] << " ";
	}
	delete slucajni; slucajni = 0; delete seed; seed = 0;
	cout << "\n\n\n\nUnesite bilo sta za KRAJ!"; getch();
	return 0;
}

