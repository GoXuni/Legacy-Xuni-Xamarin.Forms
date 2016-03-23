using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar101
{
    public static class License
    {
        public const string Key =
            "AB4BHgIeB4ZDAGEAbABlAG4AZABhAHIAMQAwADEAPNBa277Gb8fKw3J20qk1y9/c" +
            "mMt6C3caXqIZboT3qcsYj1dkNu8ozJIDyxquMbHQeZTTveOLYczVFU1Sc8ccq2qQ" +
            "KA6ENExXQCrvc2qgC4+6A+oC6WO5pbq965XCsV39G5Ytnb/XcF7s8uZs7+vICXwm" +
            "uzQBVoOkntBXBs8HA6HWh6hsOfUGo5Tz+vRpdzDcLWbOybZCZDKSYrhK81oN/sb7" +
            "RS7BSeSEYL+t5oq5l4rubgpjiGXIjPE/dUQIXjEHtUSuiFhR0yLTAexzz18Y4gbA" +
            "rbNoTbAu1OeVb2apnk6RDeZrBsE8wucSW85vHcSI2NYX/l3HifbA4pzOJ/7ZYHfJ" +
            "lvZCvoxVGWmerYgDMN12VDpV1p50bjA/JnVOH8A6dzDmsE41yy0O7TO3fiaCAhjy" +
            "PeP3g/0nyr5Ww9S87By+4CcWH8CwBRRZVRflpQGdTg348bKf6jcVluvh6zhhnQYb" +
            "9dn+aRLwj/qN1sF1bRi5VdtZppXDtq9v5Zx1ITB5i00UN498169l97Aj71y0fnko" +
            "zwkzELowI0IazTdL3xogZWYZ/4KPKYuChea5fbPd+qDMCLFoKfzpLG6EB/sOlmT0" +
            "+Aw2W8j6jEQsf/OkpHcsamXoXTLq8WtIIaJOr1S+3XjpC1cLuZYHuqsRQOW/xpwV" +
            "BpU9oou1nE0l6MP14f8wggVkMIIETKADAgECAhAiELIXSwsSf7soBS4RsyUKMA0G" +
            "CSqGSIb3DQEBBQUAMIG0MQswCQYDVQQGEwJVUzEXMBUGA1UEChMOVmVyaVNpZ24s" +
            "IEluYy4xHzAdBgNVBAsTFlZlcmlTaWduIFRydXN0IE5ldHdvcmsxOzA5BgNVBAsT" +
            "MlRlcm1zIG9mIHVzZSBhdCBodHRwczovL3d3dy52ZXJpc2lnbi5jb20vcnBhIChj" +
            "KTEwMS4wLAYDVQQDEyVWZXJpU2lnbiBDbGFzcyAzIENvZGUgU2lnbmluZyAyMDEw" +
            "IENBMB4XDTEzMDkyNDAwMDAwMFoXDTE2MTAyMzIzNTk1OVowgacxCzAJBgNVBAYT" +
            "AlVTMRUwEwYDVQQIEwxQZW5uc3lsdmFuaWExEzARBgNVBAcTClBpdHRzYnVyZ2gx" +
            "FTATBgNVBAoUDENvbXBvbmVudE9uZTE+MDwGA1UECxM1RGlnaXRhbCBJRCBDbGFz" +
            "cyAzIC0gTWljcm9zb2Z0IFNvZnR3YXJlIFZhbGlkYXRpb24gdjIxFTATBgNVBAMU" +
            "DENvbXBvbmVudE9uZTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALnL" +
            "oJqpSVVqnJLza05lTIcakcvyl7dxBxZ+cwk4Cqk6+UaC6f5Z5LvRD1+AhiARulIg" +
            "I7vPgkCf+c83iOViQWyJuXFJMnGava3AZ6X/o0DaUqzYzFOWz/MrAzOJvYMtrj/N" +
            "T9m8BWei+UkY1NWUytiSa0JINYt55i/FztxXtP7K27Lj3ZYwwUkNLOKJ4f+qkR0Q" +
            "SnygYUQQyMDOLg5vfYkDLdUQkNretBT2JZ6x6dkNcCpif5dbZ01MOFEEjZJlGdnv" +
            "renuOYfw5CNloDSCRzttSJ89JtJOjQxyrBQf1ylOXoiXCPpzAXCU2SF/dYXSimVM" +
            "8pT0NZ7pUNG1H+Az2nMCAwEAAaOCAXswggF3MAkGA1UdEwQCMAAwDgYDVR0PAQH/" +
            "BAQDAgeAMEAGA1UdHwQ5MDcwNaAzoDGGL2h0dHA6Ly9jc2MzLTIwMTAtY3JsLnZl" +
            "cmlzaWduLmNvbS9DU0MzLTIwMTAuY3JsMEQGA1UdIAQ9MDswOQYLYIZIAYb4RQEH" +
            "FwMwKjAoBggrBgEFBQcCARYcaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYTAT" +
            "BgNVHSUEDDAKBggrBgEFBQcDAzBxBggrBgEFBQcBAQRlMGMwJAYIKwYBBQUHMAGG" +
            "GGh0dHA6Ly9vY3NwLnZlcmlzaWduLmNvbTA7BggrBgEFBQcwAoYvaHR0cDovL2Nz" +
            "YzMtMjAxMC1haWEudmVyaXNpZ24uY29tL0NTQzMtMjAxMC5jZXIwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wEQYJYIZIAYb4QgEBBAQDAgQQMBYGCisG" +
            "AQQBgjcCARsECDAGAQEAAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQBhzVY5zjwYAFjm" +
            "Ia2JSWbqeXQ1jrf2o5DoRYWgI/+4LEpJ+U2o+VAI5kIYSNGp5Yjq7XvQosjs/C6q" +
            "dwpfTd3bh2lEER4XCRzpo+4HK9Wxwj0D8P1UoUn43LjlbMB/GzRRhNq0BN+ETlD0" +
            "+BejspoUssd5GRhGLNOXmtDV+9/a7j7h9t5JEMk++JblysVe6UpcgtoY9XguZLsm" +
            "5DOhQT0QIlgOIK1QSl/whiKGdPBfD5jN4/SHsGVUbPpC+Pxjh5yT/LSm9+Nqk+tz" +
            "MQQcpbTfeLKs9kLgsG4Uo9fsg5wOl4FN4CBHo2CLXEqtriy3//rpUMOutVKmm1aw" +
            "HhgGqsuFMIICuDCCAaCgAwIBAgIINEXnNiGYE0wwDQYJKoZIhvcNAQEFBQAwHDEa" +
            "MBgGA1UEAwwRR0MtU1UxMTUwMC02NjY2NjYwHhcNMTUwMTAxMDAwMDAwWhcNMTYw" +
            "NDMwMDAwMDAwWjAcMRowGAYDVQQDDBFHQy1TVTExNTAwLTY2NjY2NjCCASIwDQYJ" +
            "KoZIhvcNAQEBBQADggEPADCCAQoCggEBAKjgNZUZhiTMhfcLYJuEWCqXDwiRp/l7" +
            "0bzxLhVtS+bm3per/P0rsdAF9tKCtZP7qiY7mGqKhim1geIQkiGDo3mJwE1ZOu/T" +
            "gnmKxXjlXdvL0lI2FuFkSbUafxy4/bA6s8L1hO1G0wKs2yXrkETvUNp+SJBQG4Ze" +
            "UJUU/8F20b+3pUfehsewxooyCuxG8LJ7trHUsXRTI5yWfXhqdYltxc1kt6Ez/hBi" +
            "5Z/0T5CFTqct0bqvEE24yfM7s4KcSO0HyBKYSpPbQ5D3EGCM7x9I4AwOrxN0L3AC" +
            "9IwpHQTv4f4oAb+NYneZLzJCSDYlyjABcQkXYqpObOmnNjCEyef+rcUCAwEAATAN" +
            "BgkqhkiG9w0BAQUFAAOCAQEAMDruzKyTS8pdy0lCRmTHmRbVE3A6fg3wLSah8PHZ" +
            "oqqp/JwEK72rwl/GWq4K+1olmaeR9+hjOmOTO2mXzwHr2Veacw0Sa3NX0jT9LoB6" +
            "pKDpJXWbwLinllpdPNq+rRDaw0AkX9wr5u1Jo22cmB63bFkIhv6VzQhXTvmxpKh/" +
            "bJe0culZj7fsCXGH8//lYsaVy/mQSQqZUwZj7kneeDsFZI2tUN7YVtOlKZ/JYMfh" +
            "4PT/bfFfwmTtd4Rhddat5pKFHBo78B69OashF56VvkoiqueMiU4uPFZy6Se4gqE8" +
            "WzSzVtGNt8BEx8ry4xpxGyHC+pLnuR1TJw/qHLlFETpBvA==";
    }
}
