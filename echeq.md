# Diagrama de Ambientes de E-Cheq

En los siguientes diagramas se muestran los componentes de los distintos ambientes de E-Cheq

```
@startuml

title Configuracion Ambientes E-Cheq

left to right direction

rectangle "Produccion" {
    rectangle "API RedLink" {
        interface "443" as linkProdNatPort
        component "API RedLink Produccion (192.168.243.26)" as linkProdNat
        linkProdNatPort - linkProdNat

        interface "443" as linkProdPort
        component "API RedLink Produccion (10.2.0.26)" as linkProd

        linkProdPort - linkProd
        linkProdNat --> linkProdPort
    }

    rectangle "API Middleware" {
        interface "8010" as prod1
        interface "8010" as prod2
        component "Server Produccion 1 (BCBASV2052)"  as prodSrv1
        component "Server Produccion 2 (BCBASV2052)"  as prodSrv2
        interface "8010" as balProd
        component "Balanceador Testing (api-internas-prod)"  AS balProdSrv

        prod1 - prodSrv1 
        prod2 - prodSrv2
        balProd - balProdSrv
        balProdSrv --> prod1
        balProdSrv --> prod2

        prodSrv1 --> linkProdNatPort
        prodSrv2 --> linkProdNatPort
    }

    rectangle "COBIS Produccion" {
        component "COBIS Produccion (BCBAXP100)" as cobisProd

        cobisProd --> balProd
    }

}

rectangle "Desarrollo / Test" {

left to right direction

    rectangle "API RedLink Homologacion" {
        interface "443" as linkHomoNatPortppp
        component "API RedLink Homologacion (192.168.243.97)" as linkHomoNat

        linkHomoNatPort - linkHomoNat

        interface "443" as linkHomoPort
        component "API RedLink Homologacion (10.2.0.97)" as linkHomo

        linkHomoPort - linkHomo
        linkHomoNat --> linkHomoPort
    }

    rectangle "API Middleware Test" {

        interface "8010" as test1
        interface "8010" as test2
        component "Server Testing 1 (BCBATV1052)"  as testSrv1
        component "Server Testing 2 (BCBATV2052)"  as testSrv2
        interface "8010" as balTest
        component "Balanceador Testing (api-internas-test)"  as balTestSrv

        test1 - testSrv1 
        test2 - testSrv2
        balTest - balTestSrv
        balTestSrv --> test1
        balTestSrv --> test2

        testSrv1 --> linkHomoNatPort
        testSrv2 --> linkHomoNatPort
    }

    rectangle "COBIS Testing / Homologacion" {
        component "COBIS Testing (BCBAXT200)" as cobisTest
        component "COBIS Homologacion (BCBAXE100)" as cobisHomo

        cobisTest --> balTest
        cobisHomo --> balTest
    }

    rectangle "Desarrollo" {
        component "VPC-0103" as vpc1
        component "VPC-0009" as vpc2
        component "BCBADV2052" as dev1

        vpc1 --> linkHomoNatPort
        vpc2 --> linkHomoNatPort
        dev1 --> linkHomoNatPort
    }
}
@enduml
```