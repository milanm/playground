// 
// Program koji sortira reci ulazne tekstualne datoteke (abecedno) - po redovima,
// koriscenjem stl-a.
//
// Programer: Milan Milanovic (milan@milanovic.org)
//
// Datum: 30. avgust 2004.
//
// Datoteka: SortDat.cpp
//
// Kompajler: Microsoft Visual C++ .NET v7.1
//
#include <vector>
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// argv[1] -> naziv ulaznog fajla
// argv[2] -> naziv izlaznog fajla
int main(int argc, char *argv[])
{
	if(argc <= 0) { cout << "\nNije navedeno ime fajlova!" << endl; return 0; }
	else if(!argv[1]) { cout << "\nNije naveden ulazni fajl!" << endl; return 0; }
	else if(!argv[2]) { cout << "\nNije naveden izlazni fajl!" << endl; return 0; }

	ifstream ifajl( argv[1] ) ; ofstream fajl( argv[2] );
	vector<string>reci_u_redu;
	
	if(!ifajl)
	{ 
		cout << "\nGreska: fajl '" << argv[1] << "' ne postoji!\n" << endl;
		return 0;
	}
	if(!fajl)
	{
		cout << "\nGreska: fajl '" << argv[2] << "' ne postoji!\n" << endl;
	}

	string linija;
	while(getline(ifajl,linija))
	{
		string rec;
		for(unsigned int i = 0; i < linija.size(); i++)
		{
			if(linija[i]!=' ') rec += linija[i];
			else { if(rec.size()>0) {reci_u_redu.push_back(rec); rec="";} }
		}
		if(rec.size()>0) {reci_u_redu.push_back(rec); rec="";}

		// sortiraj
		vector<string>::iterator poc = reci_u_redu.begin(), kraj = reci_u_redu.end();
		for(unsigned int i = 0; i < reci_u_redu.size()-1; i++)
			for(unsigned int j = i + 1; j < reci_u_redu.size(); j++)
				if(reci_u_redu[j].compare(reci_u_redu[i])<0)
				{// zameni 
					string temp = reci_u_redu[j];
					reci_u_redu.erase(poc + j);
					reci_u_redu.insert(poc + j, reci_u_redu[i]);
					reci_u_redu.erase(poc + i);
					reci_u_redu.insert(poc + i, temp);
				}
		// ispisi u fajl
		for(unsigned int i = 0; i < reci_u_redu.size(); i++)
			fajl << reci_u_redu.at(i) << " ";
		fajl << endl;
		reci_u_redu.clear(); linija.clear();
    }
    ifajl.close(); fajl.close();
		
	// ispisi fajlove na standardni izlaz
	cout << "\nUlazni fajl (" << argv[1] << "):\n";
	ifstream prvi( argv[1] ) ; ifstream drugi( argv[2] ) ;
	while(getline(prvi,linija)) { cout << linija << endl; linija.clear(); }
	prvi.close(); cout << "\n\nIzlazni fajl (" << argv[2] << "):\n";
	while(getline(drugi,linija)) { cout << linija << endl; linija.clear(); }
	drugi.close();

	return 0;
}
