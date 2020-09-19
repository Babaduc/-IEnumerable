using System;
using System.Linq;
using System.Collections;
namespace EnumInterface
{
    class Program
    {
    	public class Soul
    	{
    		public string Name;
    		public int DeathYear;
    		public Soul (string name,int year)
    		{
    			Name=name;
    			DeathYear=year;
    		}
    	}
    	public class Abyss : IEnumerable
    	{
    		public Soul[] soulstorage;
    		public Abyss(Soul[] soulArray)
    		{
    			soulstorage= new Soul[soulArray.Length];
    			for (int i=0;i<soulArray.Length;i++)
    			{
    				soulstorage[i]=soulArray[i];
    			}
    		}
    		IEnumerator IEnumerable.GetEnumerator()
    		{
    			return (IEnumerator) GetEnumerator();
    		}
    		public AbyssEnum GetEnumerator()
    		{
    			return new AbyssEnum(soulstorage);
    		}
    		
    	}
    	public class AbyssEnum:IEnumerator
    	{
    		int position=-1;
    		public Soul[] soulstorage;
    		public AbyssEnum(Soul[] souls)
    		{
    			soulstorage=souls;
    		}
    		public bool MoveNext()
    		{
    			position++;
    			return (position < soulstorage.Length);
    		}
    		public void Reset()
    		{
    			position=0;
    		}
    		object IEnumerator.Current
    		{
    			get
    			{
    				return Current;
    			}
    		}
    		public Soul Current
    		{
    			get
    			{
    				try
    				{
    					return soulstorage[position];
    				}
    				catch(IndexOutOfRangeException)
    				{
    					Console.WriteLine("Error is near");
    					throw new InvalidOperationException();
    				}
    			}
    		}
    	}
        static void Main(string[] args)
        {
        	Soul[] soulArrayy=new Soul[5]
        	{
        		new Soul("Nameless1",1185),
        		new Soul("Nameless2",1227),
        		new Soul("Nameless3",1394),
        		new Soul("Nameless4",2002),
        		new Soul("Nameless5",108),
        	};
        	Abyss soulstorage= new Abyss(soulArrayy);
        	foreach(Soul s in soulstorage)
        	{
        		Console.WriteLine(s.Name+" "+s.DeathYear);
        	}
        	int i=0;
        	Console.WriteLine(" ");
        	while(i<soulArrayy.Length)
        	{
        		Console.WriteLine(soulArrayy[i].Name+" "+soulArrayy[i].DeathYear);
        		i++;
        	}
        	Console.ReadKey(true);
        }
    }
}
