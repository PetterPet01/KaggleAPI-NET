import CodeBlock from '@theme/CodeBlock';
import TabItem from '@theme/TabItem';
import Tabs from '@theme/Tabs';
import React from 'react';

const VERSION = '1.0.0';

const installCodeNuget = `Install-Package KaggleAPI.Web
`;

const installReference = `<PackageReference Include="KaggleAPI.Web" Version="${VERSION}" />
`;

const installCodeCLI = `dotnet add package KaggleAPI.Web
`;

const InstallInstructions = () => {
  return (
    <div style={{ padding: '10px' }}>
      <Tabs
        defaultValue="cli"
        values={[
          { label: '.NET CLI', value: 'cli' },
          { label: 'Package Manager', value: 'nuget' },
          { label: 'Package Reference', value: 'reference' },
        ]}
      >
        <TabItem value="cli">
          <CodeBlock language="shell" className="shell">
            {installCodeCLI}
          </CodeBlock>
        </TabItem>
        <TabItem value="nuget">
          <CodeBlock language="shell" className="shell">
            {installCodeNuget}
          </CodeBlock>
        </TabItem>
        <TabItem value="reference">
          <CodeBlock language="xml" className="xml">
            {installReference}
          </CodeBlock>
        </TabItem>
      </Tabs>
    </div>
  );
};

export default InstallInstructions;
