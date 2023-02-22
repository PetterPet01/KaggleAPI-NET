"use strict";(self.webpackChunkkaggleapi_net=self.webpackChunkkaggleapi_net||[]).push([[112],{3905:(e,t,r)=>{r.d(t,{Zo:()=>c,kt:()=>m});var n=r(7294);function a(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}function i(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(e);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,n)}return r}function o(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?i(Object(r),!0).forEach((function(t){a(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):i(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}function l(e,t){if(null==e)return{};var r,n,a=function(e,t){if(null==e)return{};var r,n,a={},i=Object.keys(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||(a[r]=e[r]);return a}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(n=0;n<i.length;n++)r=i[n],t.indexOf(r)>=0||Object.prototype.propertyIsEnumerable.call(e,r)&&(a[r]=e[r])}return a}var s=n.createContext({}),p=function(e){var t=n.useContext(s),r=t;return e&&(r="function"==typeof e?e(t):o(o({},t),e)),r},c=function(e){var t=p(e.components);return n.createElement(s.Provider,{value:t},e.children)},u="mdxType",d={inlineCode:"code",wrapper:function(e){var t=e.children;return n.createElement(n.Fragment,{},t)}},g=n.forwardRef((function(e,t){var r=e.components,a=e.mdxType,i=e.originalType,s=e.parentName,c=l(e,["components","mdxType","originalType","parentName"]),u=p(r),g=a,m=u["".concat(s,".").concat(g)]||u[g]||d[g]||i;return r?n.createElement(m,o(o({ref:t},c),{},{components:r})):n.createElement(m,o({ref:t},c))}));function m(e,t){var r=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var i=r.length,o=new Array(i);o[0]=g;var l={};for(var s in t)hasOwnProperty.call(t,s)&&(l[s]=t[s]);l.originalType=e,l[u]="string"==typeof e?e:a,o[1]=l;for(var p=2;p<i;p++)o[p]=r[p];return n.createElement.apply(null,o)}return n.createElement.apply(null,r)}g.displayName="MDXCreateElement"},2880:(e,t,r)=>{r.r(t),r.d(t,{assets:()=>s,contentTitle:()=>o,default:()=>d,frontMatter:()=>i,metadata:()=>l,toc:()=>p});var n=r(7462),a=(r(7294),r(3905));const i={id:"error_handling",title:"Error Handling"},o=void 0,l={unversionedId:"error_handling",id:"error_handling",title:"Error Handling",description:"API calls can fail when input data is malformed or the server detects issues with the request. As an example, the following request obviously fails:",source:"@site/docs/error_handling.md",sourceDirName:".",slug:"/error_handling",permalink:"/KaggleAPI-NET/docs/error_handling",draft:!1,tags:[],version:"current",frontMatter:{id:"error_handling",title:"Error Handling"},sidebar:"docs",previous:{title:"Getting Started",permalink:"/KaggleAPI-NET/docs/getting_started"},next:{title:"Configuration",permalink:"/KaggleAPI-NET/docs/configuration"}},s={},p=[{value:"KaggleAPIException",id:"kaggleapiexception",level:2}],c={toc:p},u="wrapper";function d(e){let{components:t,...r}=e;return(0,a.kt)(u,(0,n.Z)({},c,r,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("p",null,"API calls can fail when input data is malformed or the server detects issues with the request. As an example, the following request obviously fails:"),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},'List<CompetitionDataFileInquiry>? result = await api.CompetitionListFiles(\n    competition: "BadCompetitionName"\n);\n')),(0,a.kt)("p",null,"When a request fails, a ",(0,a.kt)("inlineCode",{parentName:"p"},"KaggleAPIException")," is thrown."),(0,a.kt)("h2",{id:"kaggleapiexception"},"KaggleAPIException"),(0,a.kt)("p",null,"A very general API error. The message is either ",(0,a.kt)("em",{parentName:"p"},"(1)")," parsed from the API response's JSON body or ",(0,a.kt)("em",{parentName:"p"},"(2)")," Json deserialization error messages, both with a status code in string format appended. The response is available as a public property."),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre",className:"language-csharp"},"try\n{\n    List<CompetitionDataFileInquiry>? result = await api.CompetitionListFiles(\n        competition: \"BadCompetitionName\"\n    );\n}\ncatch (KaggleAPIException e)\n{\n    //Prints:\n    /*  Permission 'competitions.get' was denied\n        Status code: 403 Forbidden  */\n    Console.WriteLine(e.Message);\n    // Prints: Forbidden\n    Console.WriteLine(e.Response?.StatusCode);\n}\n")))}d.isMDXComponent=!0}}]);