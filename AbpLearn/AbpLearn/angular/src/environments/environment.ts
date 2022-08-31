import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'AbpLearn',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44360',
    redirectUri: baseUrl,
    clientId: 'AbpLearn_App',
    responseType: 'code',
    scope: 'offline_access AbpLearn',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'AbpLearn',
    },
  },
} as Environment;
