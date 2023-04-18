using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IPManager : MonoBehaviour
{
    public TMP_Text ipTxt;
    public string localAddress;
    private void Awake()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var address in hostEntry.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
            {
                localAddress = address.ToString();
                ipTxt.text = localAddress;
                break;
            }
        }
    }
}
