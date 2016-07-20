namespace Gauges101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new GaugeSamples());
        }

        protected override void OnStart()
        {
            Xuni.Forms.Core.LicenseManager.Key = License.Key;
        }
    }

    public static class License
    {
        public const string Key = 
            "ACIBIgIiB3tHAGEAdQBnAGUAcwAxADAAMQAuAEEAcABwAFgTFvfYERbwllDDt61o" +
            "22KPt1+MUZ/ziN1gL/kO9RfMyr2+pIycmdwEY6ZgylHfOBGmU3GFZGon2t+5eTWp" +
            "5ePxF2lxBWXW5Wo2PP0eV7LWXYvSMw7vWOqaUSMi/l4nnCTmFQlLFKIYurnvExH+" +
            "NmrY8FofVyK2u4I0xws4lEzBT5nhS4FenJiC7hUhJyFdugHLd0OtyjE4c0zIrB0w" +
            "TBaK7lBoDw3bSH78uN9t8PYJqdzLGm2ulOwgsrpOZwQcGIq/l3n5vQCb1RPjeCRr" +
            "qrbpe+Mg1C2x4HLK1H87oM1ctuotwC5KX6zsDaG3d0SB3XI5uasfhw37ghGW9dw2" +
            "wP8a45nbokrSVfPGfQndMqspb3JrP326AY+Uc+23hI5Yr1PejjbdrKcco4PR4hJI" +
            "7KOcVcxeUw0o1NdBKXuDAH8LMun2nvEaAmYjNiVemnwm+VVeMwcqkKVFPwXUnkc3" +
            "Sl3AYLDl9/T19UC7oRGX2iwIAsaXLzYjlfmX9sEGeRO1pYD4E7H8a4NadkxFsxg/" +
            "qHiPmv9kj2MYZVpyN9i/MgjhR5jbP1AyxFjV5cQ6d41jVCu0raikAOJpi1ar3I4s" +
            "Vd/y8PVy5nh/01YXcsA7ji8GWFLkXlokc7ecKqBfB1T/sPeh0a8YGX1jECtA3W4b" +
            "a7GDTZ+LGsbR+zs8qC44zsMCMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCU" +
            "izANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYD" +
            "VQQGEwJKUDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkt" +
            "a3UxFzAVBgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZl" +
            "bG9wbWVudDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEB" +
            "AQUAA4IBDwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P" +
            "3q5qe6W4fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W" +
            "+p6X67XDgcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5Lrs" +
            "dO4EJG/vq60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ9" +
            "40Ho6an2pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGB" +
            "rZsNsM8P4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJ" +
            "BgNVHRMEAjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRw" +
            "Oi8vc2Yuc3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcD" +
            "MEwwIwYIKwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUF" +
            "BwICMBkMF2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUF" +
            "BwMDMFcGCCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNk" +
            "LmNvbTAmBggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYD" +
            "VR0jBBgwFoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg1" +
            "9YQSqCwFDvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgw" +
            "BgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQ" +
            "iZi+uJqsXWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J" +
            "1/DDybiqQwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe9" +
            "3bMqnJo9vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d" +
            "+CjNTW/rDfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7o" +
            "z/iQKlfGipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAqYw" +
            "ggGOoAMCAQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwFTETMBEGA1UEAwwKR0MtMEVF" +
            "RUVFRTAeFw0xNTA1MTgxODIzMTRaFw0yMDA1MTgxODIzMTRaMBUxEzARBgNVBAMM" +
            "CkdDLTBFRUVFRUUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCFoSV6" +
            "PADKQFsKeasitLeQzZSz8LysUcDu1fc2v/VpCAoWU3KAdPFovcXXsuoyI3yHdQtl" +
            "hRtGrizO9yD33oUBdkxtZjLcezzGLNFJTJ8khwdaQ5fTw8LxBz7pQLRsNzUxFAXZ" +
            "+SwX68M0xpCtzeIL90pDjXHfUQ7hKAzRCSh0x4bRW0rANeE+MS8IwH3QSUydqEdh" +
            "XMrRdmT3KTECvK0DWQMFgbEn6wxzC22htqznYqrvVvfyRdCOi3/sqUEhMpFSgtwY" +
            "KxgTbiY+clhZZmXMKe6s78zm6WSRs44KoqX76QNlvkwakXFfqLCbG93kx9T6GSqQ" +
            "IG0RGyFo1Gy9YrR/AgMBAAEwDQYJKoZIhvcNAQEFBQADggEBABEZJIC2cN+f6MmS" +
            "pvNHr5vEGOhHy6XfXXiTRUY+i2UtajQuQP5x2mU7mfsRsoKWGYUlh1N1jPUiFudZ" +
            "B3p5pkrm5TJumST9VELhrazz/kjdejS6jJEkTflG4WKmKczXAhaOrWjjwQGD2Krr" +
            "waJlOb2jiCsoHT46qfIMj8v2sRAKYz4vZJbtnHfV5lpKjC7wVfmBNpMrCXYZQHOR" +
            "2wkyPsSC1Y6XZZ6miBxjMnCfqMcxVZ2v3BiT/i5wTmqu12MimqfBRlqErRObykPu" +
            "SBBrmnjDAJBA6gtcdRZgCeA1KuIAeCRMy6AVwLHBKFKRFoEXqAGnD+coZJ2aKI7E" +
            "HFI/Imk=";
    }
}
