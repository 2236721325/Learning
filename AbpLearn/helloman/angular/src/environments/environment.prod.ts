import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'helloman',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44376',
    redirectUri: baseUrl,
    clientId: 'helloman_App',
    responseType: 'code',
    scope: 'offline_access helloman',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44376',
      rootNamespace: 'helloman',
    },
  },
} as Environment;
