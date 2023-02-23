import Link from '@docusaurus/Link';
import useBaseUrl from '@docusaurus/useBaseUrl';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import CodeBlock from '@theme/CodeBlock';
import Layout from '@theme/Layout';
import classnames from 'classnames';
import React from 'react';
import GitHubButton from 'react-github-btn';

import InstallInstructions from '../install_instructions';
import styles from './styles.module.css';

const exampleCode = `var kaggle = new KaggleClient();

kaggle.Authenticate(
    new KaggleConfiguration { username = "YourUsername", key = "YourKey" },
    method: AuthenticationMethod.Direct
);

List<CompetitionInquiry>? result = await kaggle.CompetitionsList(search: "searchTerm");

foreach (CompetitionInquiry competition in result)
    Console.WriteLine(competition.title);
`;

const features = [
  {
    title: <>Sane Defaults - Easy To Configure</>,
    imageUrl: 'img/undraw_preferences_uuo2.svg',
    description: () => (
      <>
        <code>KaggleAPI-NET</code> allows you to quickly integrate with Kaggle API by supplying sane
        configuration defaults from the start. Later on, behaviour can be customized using extensive configuration
        possibilities.
      </>
    ),
  },
  {
    title: <>All API Calls Integrated</>,
    imageUrl: 'img/undraw_project_completed_w0oq.svg',
    description: () => (
      <>
        The Kaggle API consists of over 24 API calls. <code>KaggleAPI-NET</code> provides fully typed
        requests/responses for all of them.
      </>
    ),
  },
  {
    title: <>.NET Standard 2.X</>,
    imageUrl: 'img/undraw_Devices_e67q.svg',
    description: () => (
      <>
        With the support of .NET Standard 2.X, <code>KaggleAPI-NET</code> runs on many platforms, including .NET Core,
        UWP and Xamarin.Forms (Windows, Android, iOS and Mac)
      </>
    ),
  },
  {
    title: <>Testable</>,
    imageUrl: 'img/undraw_QA_engineers_dg5p.svg',
    description: () => (
      <>
        <code>KaggleAPI-NET</code> is built with simplicity and efficacy in mind, which allows easy testing and debugging.
      </>
    ),
  },
];

function Feature({ imageUrl, title, description }) {
  const imgUrl = useBaseUrl(imageUrl);
  return (
    <div className={classnames('col col--4', styles.feature)}>
      {imgUrl && (
        <div className="text--center">
          <img className={styles.featureImage} src={imgUrl} alt={title} />
        </div>
      )}
      <h3>{title}</h3>
      <p>{description()}</p>
    </div>
  );
}

function Home() {
  const context = useDocusaurusContext();
  const { siteConfig = {} } = context;
  return (
    <Layout title={`${siteConfig.title}`} description="Documentation for the C# .NET KaggleAPI-NET Library">
      <header className={classnames('hero hero--primary', styles.heroBanner)}>
        <div className="container">
          <div className="row">
            <div className="col col--5">
              <img src="img/logo.svg" width="120" height="120" />
              <h1 className="hero__title">
                {siteConfig.title}
                <br />
                <GitHubButton
                  href="https://github.com/PetterPet01/KaggleAPI-NET"
                  data-icon="octicon-star"
                  data-size="large"
                  data-show-count="true"
                  aria-label="Star PetterPet01/KaggleAPI-NET on GitHub"
                >
                  Star
                </GitHubButton>
                <br />
                <a href="https://www.nuget.org/packages/KaggleAPI.Web/" rel="noopener noreferrer">
                  <img
                    alt="Nuget"
                    src="https://img.shields.io/nuget/vpre/KaggleAPI.Web?label=KaggleAPI.Web&style=flat-square"
                  ></img>
                  {'  '}
                </a>
              </h1>
              <p className="hero__subtitle">{siteConfig.tagline}</p>
              <div className={styles.buttons}>
                <Link
                  className={classnames('button button--outline button--secondary button--lg', styles.getStarted)}
                  to={useBaseUrl('docs/introduction')}
                >
                  Get Started
                </Link>
              </div>
            </div>
            <div className={classnames('col col--7', styles.exampleCode)}>
              <CodeBlock language="csharp" className="csharp">
                {exampleCode}
              </CodeBlock>
            </div>
          </div>
        </div>
      </header>
      <main>
        <div className="container">
          <h2 style={{ textAlign: 'center', marginTop: '30px' }}>Try it out now</h2>
          <InstallInstructions />
        </div>
        {features && features.length && (
          <section className={styles.features}>
            <div className="container">
              <div className="row">
                {features.map((props, idx) => (
                  <Feature key={idx} {...props} />
                ))}
              </div>
            </div>
          </section>
        )}
      </main>
    </Layout>
  );
}

export default Home;
