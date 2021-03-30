# Prueba Técnica
Ordenes de pedido

# Aspectos Técnicos
3 componentes:
• El componente API (SYAC_OP) exponiendo servicios REST
• El componente Windows ("WinFormsOP"),como solución, consumiendo servicios del componente api.
• El Componente Web (SYAC_OP.WEB) consumiendo servicios del componente API
  • Entity Framework Core tools
  
# Sistema de versionamiento de código
Git: https://github.com/juanflorezc/SYAC_pruebaTecnica

# Ejecución
• Descarga del codigo
• Ajustar AppSetting.conf del proyecto API(SYAC_OP/SYAC_OP) modificando la cadena de conexión
• Abrir la solucion (SYAC_OP/SYAC_OP.sln) y ejecutar el proyecto principal

Para frontend Angular
• Verifique el endpoint del api(pasos anteriores)
• ajuste, de ser necesario la ruta configurada del enpoint en enviroments.ts (apiUrl en la ruta SYAC_OP\SYAC_OP.WEB\SYACOP\src\environments\environment.ts)
• ejecute en una terminal ubicado previamente en la ruta SYAC_OP\SYAC_OP.WEB\SYACOP el comando "ng serve"

Para windows
• Abra el proyecto SYAC_OP\WinFormsOP y ejecutelo

