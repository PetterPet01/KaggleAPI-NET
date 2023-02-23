"use strict";(self.webpackChunkkaggleapi_net=self.webpackChunkkaggleapi_net||[]).push([[168],{3905:(e,t,n)=>{n.d(t,{Zo:()=>p,kt:()=>d});var a=n(7294);function i(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function r(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(e);t&&(a=a.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,a)}return n}function o(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?r(Object(n),!0).forEach((function(t){i(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):r(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function l(e,t){if(null==e)return{};var n,a,i=function(e,t){if(null==e)return{};var n,a,i={},r=Object.keys(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||(i[n]=e[n]);return i}(e,t);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);for(a=0;a<r.length;a++)n=r[a],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(i[n]=e[n])}return i}var c=a.createContext({}),u=function(e){var t=a.useContext(c),n=t;return e&&(n="function"==typeof e?e(t):o(o({},t),e)),n},p=function(e){var t=u(e.components);return a.createElement(c.Provider,{value:t},e.children)},m="mdxType",h={inlineCode:"code",wrapper:function(e){var t=e.children;return a.createElement(a.Fragment,{},t)}},s=a.forwardRef((function(e,t){var n=e.components,i=e.mdxType,r=e.originalType,c=e.parentName,p=l(e,["components","mdxType","originalType","parentName"]),m=u(n),s=i,d=m["".concat(c,".").concat(s)]||m[s]||h[s]||r;return n?a.createElement(d,o(o({ref:t},p),{},{components:n})):a.createElement(d,o({ref:t},p))}));function d(e,t){var n=arguments,i=t&&t.mdxType;if("string"==typeof e||i){var r=n.length,o=new Array(r);o[0]=s;var l={};for(var c in t)hasOwnProperty.call(t,c)&&(l[c]=t[c]);l.originalType=e,l[m]="string"==typeof e?e:i,o[1]=l;for(var u=2;u<r;u++)o[u]=n[u];return a.createElement.apply(null,o)}return a.createElement.apply(null,n)}s.displayName="MDXCreateElement"},1245:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>c,contentTitle:()=>o,default:()=>h,frontMatter:()=>r,metadata:()=>l,toc:()=>u});var a=n(7462),i=(n(7294),n(3905));const r={id:"authentication",title:"Authentication"},o=void 0,l={unversionedId:"authentication",id:"authentication",title:"Authentication",description:"We may use specific AuthenticationMethod when calling KaggleClient.Authenticate(). Given an instantiated KaggleClient, we can call Authenticate() as many times as we need on the same client.",source:"@site/docs/authentication.md",sourceDirName:".",slug:"/authentication",permalink:"/KaggleAPI-NET/docs/authentication",draft:!1,tags:[],version:"current",frontMatter:{id:"authentication",title:"Authentication"},sidebar:"docs",previous:{title:"Configuration",permalink:"/KaggleAPI-NET/docs/configuration"},next:{title:"Logging",permalink:"/KaggleAPI-NET/docs/logging"}},c={},u=[{value:"AuthenticationMethod.Direct",id:"authenticationmethoddirect",level:3},{value:"AuthenticationMethod.File",id:"authenticationmethodfile",level:3},{value:"AuthenticationMethod.Environment",id:"authenticationmethodenvironment",level:3},{value:"AuthenticationMethod.User",id:"authenticationmethoduser",level:3}],p={toc:u},m="wrapper";function h(e){let{components:t,...n}=e;return(0,i.kt)(m,(0,a.Z)({},p,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("p",null,"We may use specific ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod")," when calling ",(0,i.kt)("inlineCode",{parentName:"p"},"KaggleClient.Authenticate()"),". ",(0,i.kt)("em",{parentName:"p"},"Given an instantiated KaggleClient, we can call ",(0,i.kt)("inlineCode",{parentName:"em"},"Authenticate()")," as many times as we need on the same client.")),(0,i.kt)("p",null,"By default, the ",(0,i.kt)("inlineCode",{parentName:"p"},"method")," parameter is set to ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod.Auto"),". Internally, the client iterates through each ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod")," in order, then stops at (and returns) the successful ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod"),"."),(0,i.kt)("p",null,(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod")," is prioritized top to bottom as follows:"),(0,i.kt)("ol",null,(0,i.kt)("li",{parentName:"ol"},"AuthenticationMethod.Direct"),(0,i.kt)("li",{parentName:"ol"},"AuthenticationMethod.File"),(0,i.kt)("li",{parentName:"ol"},"AuthenticationMethod.Environment"),(0,i.kt)("li",{parentName:"ol"},"AuthenticationMethod.User")),(0,i.kt)("p",null,"We examine each authentication method:"),(0,i.kt)("h3",{id:"authenticationmethoddirect"},"AuthenticationMethod.Direct"),(0,i.kt)("p",null,"Authenticate our client using ",(0,i.kt)("strong",{parentName:"p"},"only")," ",(0,i.kt)("inlineCode",{parentName:"p"},"username")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"key")," from the provided configuration."),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"Usage:")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };\n\nvar api = new KaggleClient();\napi.Authenticate(config, method: AuthenticationMethod.Direct);\n')),(0,i.kt)("h3",{id:"authenticationmethodfile"},"AuthenticationMethod.File"),(0,i.kt)("p",null,"Authenticate our client using ",(0,i.kt)("strong",{parentName:"p"},"only")," the ",(0,i.kt)("inlineCode",{parentName:"p"},"filename")," parameter in ",(0,i.kt)("inlineCode",{parentName:"p"},"KaggleClient.Authenticate()"),". ",(0,i.kt)("inlineCode",{parentName:"p"},"filename")," is the path to a .json file under this schema: ",(0,i.kt)("inlineCode",{parentName:"p"},'{"username": string, "key": string}')),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("p",{parentName:"li"},"Suppose a file ",(0,i.kt)("inlineCode",{parentName:"p"},"kaggle.json"),". The content of ",(0,i.kt)("inlineCode",{parentName:"p"},"kaggle.json")," should be ",(0,i.kt)("inlineCode",{parentName:"p"},'{"username": "petterpet", "key": "mytotallyrandomkey"}'))),(0,i.kt)("li",{parentName:"ul"},(0,i.kt)("p",{parentName:"li"},"Usage:"))),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'var api = new KaggleClient();\nAuthenticationMethod method = api.Authenticate(\n    filename: @"kaggle.json",\n    method: AuthenticationMethod.File\n);\n')),(0,i.kt)("h3",{id:"authenticationmethodenvironment"},"AuthenticationMethod.Environment"),(0,i.kt)("p",null,"Authenticate our client using ",(0,i.kt)("strong",{parentName:"p"},"only")," two environment variables of ",(0,i.kt)("inlineCode",{parentName:"p"},"KAGGLE_USERNAME")," and ",(0,i.kt)("inlineCode",{parentName:"p"},"KAGGLE_KEY"),". Under the hood, our client calls "),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'Environment.GetEnvironmentVariable("KAGGLE_USERNAME") //or "KAGGLE_KEY"\n')),(0,i.kt)("p",null,"to get the username and key"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"Usage:")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'// Assign the environment variable at some place\nEnvironment.SetEnvironmentVariable("KAGGLE_USERNAME", MockUsername);\nEnvironment.SetEnvironmentVariable("KAGGLE_KEY", MockKey);\n\nvar api = new KaggleClient();\nAuthenticationMethod method = api.Authenticate(method: AuthenticationMethod.Environment);\n')),(0,i.kt)("h3",{id:"authenticationmethoduser"},"AuthenticationMethod.User"),(0,i.kt)("p",null,"Authenticate our client using ",(0,i.kt)("strong",{parentName:"p"},"only")," ",(0,i.kt)("inlineCode",{parentName:"p"},"kaggle.json"),". Similar to ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod.File"),", but the containing directory is defined as follows:"),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"First, retrieve and use the directory given as the ",(0,i.kt)("inlineCode",{parentName:"li"},"KAGGLE_CONFIG_DIR")," environment variable (if defined)."),(0,i.kt)("li",{parentName:"ul"},"If no ",(0,i.kt)("inlineCode",{parentName:"li"},"KAGGLE_CONFIG_DIR")," environment variable is set beforehand, use ",(0,i.kt)("inlineCode",{parentName:"li"},"{UserProfile_Directory}/.kaggle/"),", where ",(0,i.kt)("inlineCode",{parentName:"li"},"{UserProfile_Directory}")," is")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},"Environment.SpecialFolder.UserProfile\n")),(0,i.kt)("p",null,"After obtaining a valid path to our ",(0,i.kt)("inlineCode",{parentName:"p"},"kaggle.json")," file, the client authenticates similarly to ",(0,i.kt)("inlineCode",{parentName:"p"},"AuthenticationMethod.File"),"."),(0,i.kt)("ul",null,(0,i.kt)("li",{parentName:"ul"},"Usage:")),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-csharp"},'// (Optional) assign the environment variable\nEnvironment.SetEnvironmentVariable("KAGGLE_CONFIG_DIR", "@D:/KaggleNET/");\n\nvar api = new KaggleClient();\nAuthenticationMethod method = api.Authenticate(method: AuthenticationMethod.User);\n')))}h.isMDXComponent=!0}}]);