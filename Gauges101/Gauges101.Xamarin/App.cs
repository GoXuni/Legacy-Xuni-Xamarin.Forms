using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges101
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            MainPage = new Xamarin.Forms.NavigationPage(new GaugeSamples());
        }

        protected override void OnStart()
        {
            Xuni.Xamarin.Core.LicenseManager.Key = License.Key;
        }
    }

    public static class License
    {
        public const string Key =
            "ACIBIgIiB4pHAGEAdQBnAGUAcwAxADAAMQAuAEEAcABwAFeVihEbsiazOJCdM6re" +
            "V+KkPYHP3uoHcwqjo1OqfwvyHJiIt7almLcA14eRXiohVb2HnpmaX3NSBZtqLuQI" +
            "VlcYCV0rb7zeVqxg/6GuxK4Kb3AlR7mIxX5fRnuW3IOEq2xOwKFt3mYM+xv+53Xw" +
            "mFWp98a0gE3/N2VhXj3YQ2ONAyU6DlkvhuCu3/XXXtan8G5CIytRI/O9zyT4yp2a" +
            "hP3FKu1aRVPu6u+TSbxV5o9Ft7Cl0FSHhFG1ocgpBCNNVA94+lPIUtK2x695jxJv" +
            "xyLn1eB+JnO43yBbz5h5988l4kYi3rqRFBxEhaQuDZ/g8C/1Wh1Mon4n55AcplS+" +
            "PV1aijZJGsjBtUNyksD9CDuJwpLAKEjcPHVTZ6C/xzo4UYzsSfRXDq9UU9lC7v6y" +
            "gHhFh/iqsVMZapq5jUlVFBnqx4jqwvI4o5X9ovKahqY6qL1msq8298xGlhIDJb2k" +
            "HlmDCHXqmaDMuo3DMm3947czmGbvuxDUzwigTJxV44XHZXYLRUK6f3HsI8DwsJmO" +
            "/sNfZTBZZ93QqkoRIapobPjxj3qY+z9m85nZ+eYvMze5udMYASvCEsiv77+A7u+u" +
            "Cn4WZjW4jnqy0HejQa1IOyNX61n8u7CVq1+tlpk3HEhxHs25HAkMse6BkLLpu9PS" +
            "HTymi8XX/wmTyWxQna/e2vlgMIIFZDCCBEygAwIBAgIQIhCyF0sLEn+7KAUuEbMl" +
            "CjANBgkqhkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlT" +
            "aWduLCBJbmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYD" +
            "VQQLEzJUZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3Jw" +
            "YSAoYykxMDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcg" +
            "MjAxMCBDQTAeFw0xMzA5MjQwMDAwMDBaFw0xNjEwMjMyMzU5NTlaMIGnMQswCQYD" +
            "VQQGEwJVUzEVMBMGA1UECBMMUGVubnN5bHZhbmlhMRMwEQYDVQQHEwpQaXR0c2J1" +
            "cmdoMRUwEwYDVQQKFAxDb21wb25lbnRPbmUxPjA8BgNVBAsTNURpZ2l0YWwgSUQg" +
            "Q2xhc3MgMyAtIE1pY3Jvc29mdCBTb2Z0d2FyZSBWYWxpZGF0aW9uIHYyMRUwEwYD" +
            "VQQDFAxDb21wb25lbnRPbmUwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB" +
            "AQC5y6CaqUlVapyS82tOZUyHGpHL8pe3cQcWfnMJOAqpOvlGgun+WeS70Q9fgIYg" +
            "EbpSICO7z4JAn/nPN4jlYkFsiblxSTJxmr2twGel/6NA2lKs2MxTls/zKwMzib2D" +
            "La4/zU/ZvAVnovlJGNTVlMrYkmtCSDWLeeYvxc7cV7T+ytuy492WMMFJDSziieH/" +
            "qpEdEEp8oGFEEMjAzi4Ob32JAy3VEJDa3rQU9iWesenZDXAqYn+XW2dNTDhRBI2S" +
            "ZRnZ763p7jmH8OQjZaA0gkc7bUifPSbSTo0McqwUH9cpTl6Ilwj6cwFwlNkhf3WF" +
            "0oplTPKU9DWe6VDRtR/gM9pzAgMBAAGjggF7MIIBdzAJBgNVHRMEAjAAMA4GA1Ud" +
            "DwEB/wQEAwIHgDBABgNVHR8EOTA3MDWgM6Axhi9odHRwOi8vY3NjMy0yMDEwLWNy" +
            "bC52ZXJpc2lnbi5jb20vQ1NDMy0yMDEwLmNybDBEBgNVHSAEPTA7MDkGC2CGSAGG" +
            "+EUBBxcDMCowKAYIKwYBBQUHAgEWHGh0dHBzOi8vd3d3LnZlcmlzaWduLmNvbS9y" +
            "cGEwEwYDVR0lBAwwCgYIKwYBBQUHAwMwcQYIKwYBBQUHAQEEZTBjMCQGCCsGAQUF" +
            "BzABhhhodHRwOi8vb2NzcC52ZXJpc2lnbi5jb20wOwYIKwYBBQUHMAKGL2h0dHA6" +
            "Ly9jc2MzLTIwMTAtYWlhLnZlcmlzaWduLmNvbS9DU0MzLTIwMTAuY2VyMB8GA1Ud" +
            "IwQYMBaAFM+Zqep7JvRLyY6P1/AFJu/j0qedMBEGCWCGSAGG+EIBAQQEAwIEEDAW" +
            "BgorBgEEAYI3AgEbBAgwBgEBAAEB/zANBgkqhkiG9w0BAQUFAAOCAQEAYc1WOc48" +
            "GABY5iGtiUlm6nl0NY639qOQ6EWFoCP/uCxKSflNqPlQCOZCGEjRqeWI6u170KLI" +
            "7PwuqncKX03d24dpRBEeFwkc6aPuByvVscI9A/D9VKFJ+Ny45WzAfxs0UYTatATf" +
            "hE5Q9PgXo7KaFLLHeRkYRizTl5rQ1fvf2u4+4fbeSRDJPviW5crFXulKXILaGPV4" +
            "LmS7JuQzoUE9ECJYDiCtUEpf8IYihnTwXw+YzeP0h7BlVGz6Qvj8Y4eck/y0pvfj" +
            "apPrczEEHKW033iyrPZC4LBuFKPX7IOcDpeBTeAgR6Ngi1xKra4st//66VDDrrVS" +
            "pptWsB4YBqrLhTCCA/8wggLroAMCAQICBA7u7u4wCQYFKw4DAh0FADBuMQswCQYD" +
            "VQQGEwJVUzEVMBMGA1UECBMMUGVubnN5bHZhbmlhMRMwEQYDVQQHEwpQaXR0c2J1" +
            "cmdoMRIwEAYDVQQKEwlHcmFwZUNpdHkxHzAdBgNVBAMTFkdDLVh1bmlJbnRlcm5h" +
            "bExpY2Vuc2UwHhcNMTUwMTAxMDUwMDAwWhcNMjAxMjMxMDUwMDAwWjBuMQswCQYD" +
            "VQQGEwJVUzEVMBMGA1UECBMMUGVubnN5bHZhbmlhMRMwEQYDVQQHEwpQaXR0c2J1" +
            "cmdoMRIwEAYDVQQKEwlHcmFwZUNpdHkxHzAdBgNVBAMTFkdDLVh1bmlJbnRlcm5h" +
            "bExpY2Vuc2UwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCzDkjFKR61" +
            "Y9eAJ3QKbaseStWsilLrh9J+r25MH4bBOrGpEWNJg7q36zO9XZBmxsfTDbEMpJy0" +
            "ztuJHPKkT7fRHTHk9fXpAKgVHL970LHn5u0HhcB+91mgg47uNQP6Ne0lTl5N3re/" +
            "xWkfdiG4k7KlVWrj97fHJQ23ExL3eCSRMykC46wy9rt8X7h9GHPDt48nL5aco+GL" +
            "NNOL5B5YlTNmLmtr3h2FKu/DFM0Mr9iVuNZVz0Fhz8hJupDIDU53jKKPODxsCxVV" +
            "B0iSQrhPJ0gJUt9APjs8irU4zTLDZL7088QwR9vR2naUIS8bzd7VCnmxYkVO7PHo" +
            "XAD0cegiGUkVAgMBAAGjgawwgakwDwYDVR0TAQH/BAUwAwEB/zCBlQYDVR0BBIGN" +
            "MIGKgBB5Fo8jjlcXMxj74gWbhNUGoXAwbjELMAkGA1UEBhMCVVMxFTATBgNVBAgT" +
            "DFBlbm5zeWx2YW5pYTETMBEGA1UEBxMKUGl0dHNidXJnaDESMBAGA1UEChMJR3Jh" +
            "cGVDaXR5MR8wHQYDVQQDExZHQy1YdW5pSW50ZXJuYWxMaWNlbnNlggQO7u7uMAkG" +
            "BSsOAwIdBQADggEBAFl7HDV++Gvp7WzNEc/ehSCDIT8ObGBk58Sh0L20BQAnYWeP" +
            "0UiVOw/DtQaApaxKOVm+tHSI725SzN0d09ldxinvmdnyBnpWijz5c+OVXWl61xdI" +
            "4sUXUF0ete/dm2OvypcM75GmAV6KNRWQ4g3OajlEwAEIfwzF/VlhWck9YmLoe0o3" +
            "vy0FlZsPuLVeOWJTv2OwpZ95+Q/R9FtX/V8tjm9HW30uex5+Eb/sX8LzaG7C01yb" +
            "2IQw9MM4EK3v+hbuSCgOCORnlwZjIwRrF/J7xLxiDoBH2hzJJPSF11LMI8uPACvF" +
            "b5sneYs+TYj4UsLKyL6Dgdzx36aglG0i6JoyhZ8=";
    }
}
