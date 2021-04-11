
package inicjaly;

public class pasowanie
{
public void dopasuj(int n, int my, double[] x, double[] y,int[] ro,int[] xe, int[] ye)
    {
    int xmin=ro[0],ymin=ro[1],xmax=ro[2],ymax=ro[3],i;
    double xrmin=x[0],yrmin=y[0],xrmax=x[0],yrmax=y[0],tx,ty;

    for(i=1;i<n;i++)
    {
    if(x[i]<xrmin) 
        xrmin=x[i];
    
    if(x[i]>xrmax) 
        xrmax=x[i];
    
    if(y[i]<yrmin) 
        yrmin=y[i];
    
    if(y[i]>yrmax) 
        yrmax=y[i];
    }
    tx=xmin-xrmin;
    ty=ymin-yrmin;
    
    for(i=0;i<n;i++)
    {
    x[i]+=tx;
    y[i]+=ty;
    }
    xrmin+=tx;
    xrmax+=tx;
    yrmin+=ty;
    yrmax+=ty;

    double sx,sy;
    sx=(xmax-xmin)/(xrmax-xrmin);
    sy=(ymax-ymin)/(yrmax-yrmin);

    if(sx<sy) sy=sx;
    else sx = sy;

    for(i=0;i<n;i++)
    {
    x[i]=sx*(x[i]-xmin)+xmin;
    y[i]=sy*(y[i]-ymin)+ymin;
    }

    for(i=0;i<n;i++)
    {
    xe[i]=(int) x[i];
    ye[i]=my - (int) y[i];
    }
  }   
}
