# GetEverything
可以获取u3d脚本上任何变量（主要针对Int64、字典）或属性值，直接在inspctor上可见。

基本思路：
采用一个寄生变量的PropertyDrawer获取到该类的信息，通过反射获取所有想要的信息，并在Inspector上显示出来

