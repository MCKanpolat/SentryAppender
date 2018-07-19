# SharpRaven.Log4Net.Core

[log4net](http://logging.apache.org/log4net/) appender to send errors to [Sentry](http://www.getsentry.com/).

## Installation

    PM> Install-Package SharpRaven.Log4Net.Core
	dotnet add package SharpRaven.Log4Net.Core

## Configuration

Configure in app.config:

```xml
<log4net>
	<root>
		<level value="DEBUG" />
		<appender-ref ref="SentryAppender" />
	</root>
	<appender name="SentryAppender" type="SharpRaven.Log4Net.Core.SentryAppender, SharpRaven.Log4Net.Core">
		<DSN value="DSN_FROM_SENTRY_UI" />
		<Environment value="Production" />
		<Logger value="LOGGER_NAME" />
		<threshold value="ERROR" />
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date{yyyy-MM-dd HH:mm:ss.fff} [%thread] [%property{Context}] %-5level %logger - %message%newline" />
		</layout>
	</appender>
</log4net>
```

### Building the project

    dotnet build

## Contribute

If you have any idea for an improvement or found a bug, do not hesitate to open an issue.


## License

SharpRaven.Log4Net.Core is distributed under MIT License.
