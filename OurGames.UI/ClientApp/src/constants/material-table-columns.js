import React, { Fragment } from 'react';
import { formatRawValue } from '../utils/funcs';
import format from 'date-fns/format';

export const GAME_COLUMNS = [
  {
    title: 'Nome',
    field: 'name'
  },
  {
    title: 'ID',
    field: 'id',
    type: 'numeric',
    hidden: true
  },
  {
    title: 'Thumb',
    field: 'thumbnailLink',
    hidden: true
  },
  {
    title: 'Background',
    field: 'backgroundLink',
    hidden: true
  },
  {
    title: 'Descrição',
    field: 'description',
    hidden: true
  },
  {
    title: 'Requisitos',
    field: 'requirements',
    hidden: true
  },
  {
    title: 'Desenvolvedor',
    field: 'developer'
  },
  {
    title: 'Classificação',
    field: 'rating'
  },
  {
    title: 'Publicador',
    field: 'publisher'
  },
  {
    title: 'Data de lançamento',
    field: 'launchDate',
    render: rowData => format(Date.parse(rowData.launchDate), 'dd/MM/yyyy')
  },
  {
    title: 'Preço',
    field: 'price',
    type: 'numeric',
    render: rowData => formatRawValue(rowData.price, 'R$')
  },
  {
    title: 'Ativo',
    field: 'active',
    type: 'boolean',
    sorting: false
  },
  {
    title: 'Plataformas',
    field: 'plataformsView',
    render: rowData => {
      const plataforms = [];
      for (let i = 0; i < rowData.plataformsView.length; i++) {
        const plataform = rowData.plataformsView[i];
        plataforms.push(
          <Fragment key={i}>
            <span>{plataform}</span>
            <br />
          </Fragment>
        );
      }
      return plataforms;
    },
    hidden: true
  },
  {
    title: 'Vídeos',
    field: 'videos',
    render: rowData => {
      const videos = [];
      for (let i = 0; i < rowData.videos.length; i++) {
        const video = rowData.videos[i];
        videos.push(
          <Fragment key={i}>
            <span>{video}</span>
            <br />
          </Fragment>
        );
      }
      return videos;
    },
    hidden: true
  },
  {
    title: 'Categorias',
    field: 'categoriesView',
    render: rowData => {
      const categories = [];
      for (let i = 0; i < rowData.categoriesView.length; i++) {
        const category = rowData.categoriesView[i];
        categories.push(
          <Fragment key={i}>
            <span>{category}</span>
            <br />
          </Fragment>
        );
      }
      return categories;
    },
    hidden: true
  }
];
