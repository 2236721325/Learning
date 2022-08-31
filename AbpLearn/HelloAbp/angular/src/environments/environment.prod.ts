import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'HelloAbp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44386',
    redirectUri: baseUrl,
    clientId: 'HelloAbp_App',
    responseType: 'code',
    scope: 'offline_access HelloAbp',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44386',
      rootNamespace: 'HelloAbp',
    },
  },
} as Environment;
